using Plugin.MauiWifiManager;
using Plugin.MauiWifiManager.Abstractions;

using static Android.Graphics.ColorSpace;

namespace StorageManager.DeviceConfigurator.Components.Pages
{
    public partial class Home()
    {
        private List<NetworkData> networks = new List<NetworkData>();

        protected override async Task OnInitializedAsync()
        {
            await Scan();
            await base.OnInitializedAsync();
        }

        public async Task Connect(NetworkData model)
        {
            try
            {

                var status = await CrossWifiManager.Current.ConnectWifi(model.Ssid, "12345678");
                var state = await CrossWifiManager.Current.GetNetworkInfo();

                await Task.Delay(5000);
                var httpClient = new HttpClient() { BaseAddress = new Uri("http://192.168.1.1") };
                var deviceInfo = await httpClient.GetAsync("infos");
            }
            catch (Exception ex)
            {
            }
        }

        public async Task DeviceInfos()
        {
            try
            {
                var httpClient = new HttpClient() { BaseAddress = new Uri("http://192.168.1.1") };
                var deviceInfo = await httpClient.GetAsync("infos");
            }
            catch (Exception ex)
            {
            }
        }

        public async Task Scan()
        {
            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted || DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            {
                var networksScanned = await CrossWifiManager.Current.ScanWifiNetworks();
                networks = networksScanned.Where(n => n.Ssid.Contains("ESP")).ToList();
            }
        }
    }
}
