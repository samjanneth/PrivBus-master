//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Firebase;
//using Firebase.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace App5.Droid.Helpers
//{
//    public static class AppDataHelper
//    {

//        public static FirebaseDatabase GetFirebaseDatabase()
//        {
//            var app = FirebaseApp.InitializeApp(Application.Context);
//            FirebaseDatabase database;

//            if(app == null)
//            {
//                var option = new FirebaseOptions.Builder()
//                    .SetApplicationId("privbus-1736c")
//                    .SetApiKey("AIzaSyB8qLdTZYAc4VMm3FURcZebRlT2TVOV75E")
//                    .SetDatabaseUrl("https://privbus-1736c.firebaseio.com")
//                    .SetStorageBucket("privbus-1736c.appspot.com")
//                    .Build();

//                app = FirebaseApp.InitializeApp(Application.Context, option);
//                database = FirebaseDatabase.GetInstance(app);


//            }
//            else
//            {
//                database = FirebaseDatabase.GetInstance(app);
//            }

//            return database;

//        }

//    }
//}