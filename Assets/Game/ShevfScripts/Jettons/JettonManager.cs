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
        // создание HTTP параметров дл€ ton клиента
        HttpParameters tonClientParams = new HttpParameters
        {
            Endpoint = "https://toncenter.com/api/v2/jsonRPC",
            ApiKey = "959bdd5b2634e15a1c14182f6d3d3cff8cbc2084c482d2272eeece573fb334c6"
        };

        // создание ton клиента дл€ получени€ данных и отправки boc
        tonClient = new TonClient(TonClientType.HTTP_TONCENTERAPIV2, tonClientParams);

        // создание нового мнемоника или использование существующего
        mnemonic = new Mnemonic();

        // создание опций дл€ кошелька
        WalletV4Options optionsV4 = new WalletV4Options()
        {
            PublicKey = mnemonic.Keys.PublicKey,
        };

        // создание экземпл€ра кошелька
        wallet = new WalletV4(optionsV4, 2);

        // создание опций с метаданными в цепи
        JettonMinterOptions opts = new JettonMinterOptions()
        {
            AdminAddress = wallet.Address,
            JettonContent = new JettonOnChainContent()
            {
                Name = "ћой Ћучший “окен",
                Symbol = "MLT",
                Description = "Ёто лучшее описание.",
                Decimals = 9,
                Image = "https://example.com/image.png"
            }
        };

        // создание jetton minter с опци€ми
        minter = new JettonMinter(opts);

        // выполнение развертывани€ jetton minter
        await DeployJettonMinter();

        // чеканка jettons
        await MintJettons();
    }

    private async Task DeployJettonMinter()
    {
        // получение seqno с использованием tonClient
        uint? seqno = await tonClient.Wallet.GetSeqno(wallet.Address);

        // создание сообщени€ дл€ депло€ jetton minter
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
                Mode = 3 // режим сообщени€
            }
        }, seqno ?? 0).Sign(mnemonic.Keys.PrivateKey);

        // отправка этого сообщени€ через TonClient
        await tonClient.SendBoc(msg.Cell);

        // печать адреса главного контракта jetton
        Debug.Log("Jetton Minter Address: " + minter.Address);
    }

    private async Task MintJettons()
    {
        // создание опций дл€ чеканки jetton
        JettonMintOptions mintOptions = new JettonMintOptions()
        {
            JettonAmount = new Coins(10000000), // количество jetton дл€ чеканки
            Amount = new Coins(0.05), // сумма, отправл€ема€ на jetton кошелек
            Destination = wallet.Address // адрес, который получит jetton
        };

        // создание тела запроса на чеканку jetton
        Cell jettonMintBody = JettonMinter.CreateMintRequest(mintOptions);

        // получение seqno с использованием tonClient
        uint? seqno = await tonClient.Wallet.GetSeqno(wallet.Address);

        // создание сообщени€ дл€ чеканки
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
                Mode = 3 // режим сообщени€
            }
        }, seqno ?? 0).Sign(mnemonic.Keys.PrivateKey);

        // отправка этого сообщени€ через TonClient
        await tonClient.SendBoc(msg.Cell);

        // подтверждение успешной чеканки
        Debug.Log("Jettons minted successfully.");
    }
}
