// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using TextureExplorer.Models;
using TextureExplorer.Services;

namespace TextureExplorer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            fileMan = new FileManager();
            winMan = new WindowManager();

            AllTextures = new(fileMan.ReadDatabase());
            SetCategories();
            Message = "Loaded";

            Version ver = Assembly.GetExecutingAssembly().GetName().Version ?? new Version();
            Title = $"Texture Explorer - {ver.ToString(4)}";
        }


        private readonly IFileManager fileMan;
        private readonly IWindowManager winMan;

        public ObservableCollection<Texture> AllTextures { get; private set; }
        public ObservableCollection<Texture> Results { get; } = new();
        public ObservableCollection<string> Categories { get; } = new();

        public string Title { get; }

        private string? _selCat;
        public string? SelectedCategory
        {
            get => _selCat;
            set
            {
                if (SetProperty(ref _selCat, value))
                {
                    // Filter here
                    Results.Clear();
                    if (value is null)
                    {
                        return;
                    }

                    foreach (var item in AllTextures)
                    {
                        if (item.Category == value)
                        {
                            Results.Add(item);
                        }
                    }
                }
            }
        }

        private void SetCategories()
        {
            Categories.Clear();
            foreach (var item in AllTextures)
            {
                if (!Categories.Contains(item.Category))
                {
                    Categories.Add(item.Category);
                }
            }
        }

        private string _msg = string.Empty;
        public string Message
        {
            get => _msg;
            set => SetProperty(ref _msg, value);
        }

        private bool _isSave = false;
        public bool IsSaveEnabled
        {
            get => _isSave;
            set => SetProperty(ref _isSave, value);
        }


        public void Save()
        {
            fileMan.WriteDatabase(AllTextures.ToArray());
            IsSaveEnabled = false;
        }

        public async void SetTextureDir()
        {
            fileMan.TextureDir = await winMan.OpenFolderDialog();
            IsSaveEnabled = true;
        }

        public async void Update()
        {
            IEnumerable<Texture> updateList = fileMan.ReadTextureFiles();
            List<Texture> final = new();
            foreach (Texture item in updateList)
            {
                bool found = false;
                for (int i = 0; i < AllTextures.Count; i++)
                {
                    if (AllTextures[i].Dir == item.Dir)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    final.Add(item);
                }
            }

            if (final.Count == 0)
            {
                Message = "Already up to date";
            }
            else
            {
                UpdateViewModel vm = new(final);
                await winMan.ShowDialog(vm);
                if (vm.Processed.Count != 0)
                {
                    SelectedCategory = null;
                    foreach (var item in vm.Processed)
                    {
                        AllTextures.Add(item);
                    }

                    Message = $"Added {vm.Processed.Count} new items.";
                    IsSaveEnabled = true;
                    SetCategories();
                }
            }
        }
    }
}
