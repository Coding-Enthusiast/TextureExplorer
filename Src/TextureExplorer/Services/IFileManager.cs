// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System.Collections.Generic;
using TextureExplorer.Models;

namespace TextureExplorer.Services
{
    public interface IFileManager
    {
        string TextureDir { get; set; }
        Texture[] ReadDatabase();
        void WriteDatabase(Texture[] items);
        IEnumerable<Texture> ReadTextureFiles();
    }
}
