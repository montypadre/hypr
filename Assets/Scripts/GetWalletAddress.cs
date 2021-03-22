using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// use web3.jslib
using System.Runtime.InteropServices;

public class GetWalletAddress : MonoBehaviour
{
    // use WalletAddress function from web3.jslib
    [DllImport("__Internal")] private static extern string WalletAddress();
}
