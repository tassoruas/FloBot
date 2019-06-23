using System;
using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;

namespace FloBot
{
    public class Licensing
    {
        public void GenerateComputerId()
        {
            string cpuInfo = "";
            string hddInfo = "";
            string macInfo = "";
            ManagementClass managementClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();

            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = managementObject.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            Debug.WriteLine("Processor ID: " + cpuInfo);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject info in searcher.Get())
            {
                if (hddInfo == "")
                {
                    hddInfo = info["SerialNumber"].ToString();
                }
                Debug.WriteLine("Disk info: DeviceID: " + info["DeviceID"].ToString());
                Debug.WriteLine("Disk info: Model: " + info["Model"].ToString());
                Debug.WriteLine("Disk info: Interface: " + info["InterfaceType"].ToString());
                Debug.WriteLine("Disk info: Serial: " + info["SerialNumber"].ToString());
            }


            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface netInterface in networkInterfaces)
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up && netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback && !netInterface.Description.Contains("Virtual"))
                {
                    if (macInfo == "")
                    {
                        macInfo = netInterface.GetPhysicalAddress().ToString();
                    }
                    Debug.WriteLine("Network card info: " + netInterface.GetPhysicalAddress().ToString());
                }
            }

            string uniqueComputerId = cpuInfo + hddInfo + macInfo;

            byte[] bytes = Encoding.ASCII.GetBytes(uniqueComputerId);
            string encrypted = Convert.ToBase64String(bytes);

            bytes = Convert.FromBase64String(encrypted);
            string decrypted = Encoding.ASCII.GetString(bytes);

            Debug.WriteLine("Unique computer id: " + uniqueComputerId);
            Debug.WriteLine("Unique computer id encrypted: " + encrypted);
            Debug.WriteLine("Unique computer id decrypted: " + decrypted);
        }
    }
}
