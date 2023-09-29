// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using TextureExplorer.Models;

namespace TextureExplorer.ViewModels
{
    public class UpdateViewModel : ViewModelBase
    {
        public UpdateViewModel(IEnumerable<Texture> lst)
        {
            AllTextures = lst;
        }


        public IEnumerable<Texture> AllTextures { get; }
        public ObservableCollection<Texture> Processed { get; } = new();

        private Texture? _selTex;
        public Texture? SelectedTexture
        {
            get => _selTex;
            set => SetProperty(ref _selTex, value);
        }

        private string _tag = string.Empty;
        public string TagToAdd
        {
            get => _tag;
            set => SetProperty(ref _tag, value);
        }


        public void AddTag()
        {
            if (!string.IsNullOrEmpty(TagToAdd) && SelectedTexture is not null)
            {
                SelectedTexture.Tags.Add(TagToAdd);
                TagToAdd = string.Empty;
            }
        }


        public void Add()
        {
            if (SelectedTexture is not null)
            {
                Processed.Add(SelectedTexture);
            }
        }
    }
}
