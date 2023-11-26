using Firebase.Auth;
using Firebase.Auth.Providers;
using Google.Cloud.Firestore;

namespace WebAPI.Authentication
{
    public static class FirebaseConfig
    {
        public static readonly FirebaseAuthConfig AuthConfig = new()
        {
            ApiKey = "AIzaSyDs9OP2flHfIkgrqzFrejym8Qywjr-3k54",
            AuthDomain = "okpp-a6a02.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            },
        };

        public static readonly FirestoreDb database = FirestoreDb.Create("okpp-a6a02");
    }
}
