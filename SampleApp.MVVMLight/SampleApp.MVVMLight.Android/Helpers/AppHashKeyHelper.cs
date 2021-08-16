using Android.Content;
using Android.Content.PM;
using Android.Util;
using Java.Security;
using Java.Util;
using System;
using System.Linq;
using System.Text;

namespace SampleApp.MVVMLight.Droid.Helpers
{
    public class AppHashKeyHelper
    {
        private static string HASH_TYPE = "SHA-256";
        private static int NUM_HASHED_BYTES = 9;
        private static int NUM_BASE64_CHAR = 11;

        /// <summary>
        /// Retrieve the app signed package signature
        /// known as signed keystore file hex string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string GetPackageSignature(Context context)
        {
            PackageManager packageManager = context.PackageManager;
            var signatures = packageManager.GetPackageInfo(context.PackageName, PackageInfoFlags.Signatures).Signatures;
            return signatures.First().ToCharsString();
        }

        /// <summary>
        /// Gets the app hash key.
        /// </summary>
        /// <returns>The app hash key.</returns>
        /// <param name="context">Android app Context.</param>
        public static string GetAppHashKey(Context context)
        {
            string keystoreHexSignature = GetPackageSignature(context);

            String appInfo = context.PackageName + " " + keystoreHexSignature;
            try
            {
                MessageDigest messageDigest = MessageDigest.GetInstance(HASH_TYPE);
                messageDigest.Update(Encoding.UTF8.GetBytes(appInfo));
                byte[] hashSignature = messageDigest.Digest();

                hashSignature = Arrays.CopyOfRange(hashSignature, 0, NUM_HASHED_BYTES);
                String base64Hash = Android.Util.Base64.EncodeToString(hashSignature, Base64Flags.NoPadding | Base64Flags.NoWrap);
                base64Hash = base64Hash.Substring(0, NUM_BASE64_CHAR);

                return base64Hash;
            }
            catch (NoSuchAlgorithmException e)
            {
                return null;
            }
        }
    }
}
