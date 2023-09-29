// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextureExplorer.ViewModels;

namespace TextureExplorer.Services
{
    public class WindowManager : IWindowManager
    {
        public Task ShowDialog(ViewModelBase vm)
        {
            Window win = new()
            {
                Content = vm,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false,
                Width = 600,
                Height = 600,
                Title = vm.GetType().Name.Replace("ViewModel", ""),
            };

            //vm.CLoseEvent += (s, e) => win.Close();

            var lf = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
            return win.ShowDialog(lf.MainWindow);
        }

        public async Task<string> OpenFolderDialog()
        {
            var lf = Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
            TopLevel? topLevel = TopLevel.GetTopLevel(lf?.MainWindow);
            FolderPickerOpenOptions opt = new()
            {
                Title = "",
                AllowMultiple = false,
            };
            IReadOnlyList<IStorageFolder> result = await topLevel?.StorageProvider.OpenFolderPickerAsync(opt);
            return result[0].Path.LocalPath;
        }
    }
}
