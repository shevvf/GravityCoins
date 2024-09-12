mergeInto(LibraryManager.library, {

 saveProgress: function(keyPtr, jsonValuePtr) {
        var key = UTF8ToString(keyPtr);
        var jsonValue = UTF8ToString(jsonValuePtr);
        saveProgress(key, jsonValue); 
    },

  inviteFriends: function(joinUrl) {
        var url = UTF8ToString(joinUrl);
        inviteFriends(url); 
    },
});