using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace ResocashAPI.Authentication
{
    internal class FirebaseAppSnippets
    {
        internal static void InitSdkWithServiceAccount()
        {
            // [START initialize_sdk_with_service_account]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("D:\flutter-demo-9b5c4-firebase-adminsdk-eijdc-e44980bc73.json"),
            });
            // [END initialize_sdk_with_service_account]
        }
        internal static void InitSdkWithApplicationDefault()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
        }
        internal static void InitSdkWithRefreshToken()
        {
            // [START initialize_sdk_with_refresh_token]
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("path/to/refreshToken.json"),
            });
            // [END initialize_sdk_with_refresh_token]
        }

        internal static void InitSdkWithDefaultConfig()
        {
            // [START initialize_sdk_with_default_config]
            FirebaseApp.Create();
            // [END initialize_sdk_with_default_config]
        }

        internal static void InitDefaultApp()
        {
            // [START access_services_default]
            // Initialize the default app
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault(),
            });
            Console.WriteLine(defaultApp.Name); // "[DEFAULT]"

            // Retrieve services by passing the defaultApp variable...
            var defaultAuth = FirebaseAuth.GetAuth(defaultApp);

            // ... or use the equivalent shorthand notation
            defaultAuth = FirebaseAuth.DefaultInstance;
            // [END access_services_default]
        }
    }
}
