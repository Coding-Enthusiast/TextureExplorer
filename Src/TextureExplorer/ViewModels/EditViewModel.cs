// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using TextureExplorer.Models;

namespace TextureExplorer.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        public EditViewModel(Texture? t)
        {
            SelectedTexture = t;
        }


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
                string t = TagToAdd.Clean();
                if (t is not null)
                {
                    SelectedTexture.Tags.Add(t);
                    TagToAdd = string.Empty;
                }
            }
        }
    }
}
