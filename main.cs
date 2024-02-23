 private void Application_Startup(object sender, StartupEventArgs e)
        {
            settings = new AppSettings();
            helper = new PaletteHelper();
            devices = new ObservableCollection<Device>();

            foreach (var device in settings.Devices)
            {
                devices.Add(device);
            }

            Mode.Setup(App.settings.TotalLeds);

            foreach (var item in settings.Colors)
            {
                Mode.Colors.Add(item);
            }



       if (startArg != null && App.settings.AutoStart)
            {
                foreach (var arg in startArg)
                {
                    if (arg.Contains("autostart"))
                    {
                        autoStarted = true;
                        window.Hide();
                        App.StartStopDevices();
                        break;
                    }
                }
            }
