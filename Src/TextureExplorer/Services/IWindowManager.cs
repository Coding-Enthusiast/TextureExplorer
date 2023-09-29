// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System.Threading.Tasks;
using TextureExplorer.ViewModels;

namespace TextureExplorer.Services
{
    public interface IWindowManager
    {
        Task ShowDialog(ViewModelBase vm);
        Task<string> OpenFolderDialog();
    }
}
