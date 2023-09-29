// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;

namespace TextureExplorer.Models
{
    public class Texture : ObservableObject
    {
        public Texture()
        {
        }

        public Texture(string dir, string category)
        {
            Dir = dir;
            Name = new DirectoryInfo(dir).Name;
            Category = category;
        }

        public Texture(string dir) : this(dir, "Others")
        {
        }


        public string Dir { get; set; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Category { get; set; }

        public ObservableCollection<string> Tags { get; set; } = new();
    }
}
