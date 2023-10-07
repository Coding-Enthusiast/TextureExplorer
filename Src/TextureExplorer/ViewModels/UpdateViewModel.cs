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
            set
            {
                if (SetProperty(ref _selTex, value))
                {
                    EditVm = new EditViewModel(value);
                }
            }
        }

        private EditViewModel _evm = new(null);
        public EditViewModel EditVm
        {
            get => _evm;
            set => SetProperty(ref _evm, value);
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
