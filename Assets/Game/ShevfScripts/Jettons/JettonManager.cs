using System.Threading.Tasks;

using TonSdk.Client;
using TonSdk.Contracts.Jetton;
using TonSdk.Contracts.Wallet;
using TonSdk.Core;
using TonSdk.Core.Block;
using TonSdk.Core.Boc;
using TonSdk.Core.Crypto;

using UnityEngine;

public class JettonManager : MonoBehaviour
{
    private TonClient tonClient;
    private WalletV4 wallet;
    private Mnemonic mnemonic;
    private JettonMinter minter;

    private async void Start()
    {
        // �������� HTTP ���������� ��� ton �������
        HttpParameters tonClientParams = new HttpParameters
        {
            Endpoint = "https://toncenter.com/api/v2/jsonRPC",
            ApiKey = "959bdd5b2634e15a1c14182f6d3d3cff8cbc2084c482d2272eeece573fb334c6"
        };

        // �������� ton ������� ��� ��������� ������ � �������� boc
        tonClient = new TonClient(TonClientType.HTTP_TONCENTERAPIV2, tonClientParams);

        // �������� ������ ��������� ��� ������������� �������������
        mnemonic = new Mnemonic();

        // �������� ����� ��� ��������
        WalletV4Options optionsV4 = new WalletV4Options()
        {
            PublicKey = mnemonic.Keys.PublicKey,
        };

        // �������� ���������� ��������
        wallet = new WalletV4(optionsV4, 2);

        // �������� ����� � ����������� � ����
        JettonMinterOptions opts = new JettonMinterOptions()
        {
            AdminAddress = wallet.Address,
            JettonContent = new JettonOnChainContent()
            {
                Name = "��� ������ �����",
                Symbol = "MLT",
                Description = "��� ������ ��������.",
                Decimals = 9,
                Image = "https://example.com/image.png"
            }
        };

        // �������� jetton minter � �������
        minter = new JettonMinter(opts);

        // ���������� ������������� jetton minter
        await DeployJettonMinter();

        // ������� jettons
        await MintJettons();
    }

    private async Task DeployJettonMinter()
    {
        // ��������� seqno � �������������� tonClient
        uint? seqno = await tonClient.Wallet.GetSeqno(wallet.Address);

        // �������� ��������� ��� ������ jetton minter
        var msg = wallet.CreateTransferMessage(new[]
        {
            new WalletTransfer
            {
                Message = new InternalMessage(new InternalMessageOptions
                {
                    Info = new IntMsgInfo(new IntMsgInfoOptions
                    {
                        Dest = minter.Address,
                        Value = new Coins(0.05)
                    }),
                    Body = null,
                    StateInit = minter.StateInit
                }),
                Mode = 3 // ����� ���������
            }
        }, seqno ?? 0).Sign(mnemonic.Keys.PrivateKey);

        // �������� ����� ��������� ����� TonClient
        await tonClient.SendBoc(msg.Cell);

        // ������ ������ �������� ��������� jetton
        Debug.Log("Jetton Minter Address: " + minter.Address);
    }

    private async Task MintJettons()
    {
        // �������� ����� ��� ������� jetton
        JettonMintOptions mintOptions = new JettonMintOptions()
        {
            JettonAmount = new Coins(10000000), // ���������� jetton ��� �������
            Amount = new Coins(0.05), // �����, ������������ �� jetton �������
            Destination = wallet.Address // �����, ������� ������� jetton
        };

        // �������� ���� ������� �� ������� jetton
        Cell jettonMintBody = JettonMinter.CreateMintRequest(mintOptions);

        // ��������� seqno � �������������� tonClient
        uint? seqno = await tonClient.Wallet.GetSeqno(wallet.Address);

        // �������� ��������� ��� �������
        var msg = wallet.CreateTransferMessage(new[]
        {
            new WalletTransfer
            {
                Message = new InternalMessage(new InternalMessageOptions
                {
                    Info = new IntMsgInfo(new IntMsgInfoOptions
                    {
                        Dest = minter.Address,
                        Value = new Coins(0.05)
                    }),
                    Body = jettonMintBody
                }),
                Mode = 3 // ����� ���������
            }
        }, seqno ?? 0).Sign(mnemonic.Keys.PrivateKey);

        // �������� ����� ��������� ����� TonClient
        await tonClient.SendBoc(msg.Cell);

        // ������������� �������� �������
        Debug.Log("Jettons minted successfully.");
    }
}
