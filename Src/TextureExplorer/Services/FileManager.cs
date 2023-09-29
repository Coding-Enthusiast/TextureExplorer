// Texture Explorer
// Copyright (c) 2023 Coding Enthusiast
// Distributed under the MIT software license, see the accompanying
// file LICENCE or http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using TextureExplorer.Models;

namespace TextureExplorer.Services
{
    public class FileManager : IFileManager
    {
        public FileManager()
        {
            // Main directory is C:\Users\USERNAME\AppData\Roaming\Autarkysoft\TextureExplorer on Windows
            // or ~/.config/Autarkysoft/TextureExplorer on Unix systems such as Linux

            mainDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Autarkysoft", "TextureExplorer");

            if (!Directory.Exists(mainDir))
            {
                Directory.CreateDirectory(mainDir);
            }
        }


        private const string DatabaseName = "data";
        private const string TextureDirName = "TextureDir";
        private readonly string mainDir;

        public string TextureDir { get; set; }

        public Texture[] ReadDatabase()
        {
            TextureDir = ReadText(TextureDirName);
            return ReadJson<Texture[]>(DatabaseName) ?? Array.Empty<Texture>();
        }

        public void WriteDatabase(Texture[] items)
        {
            WriteJson(items, DatabaseName);
            WriteText(TextureDirName, TextureDir);
        }

        public IEnumerable<Texture> ReadTextureFiles()
        {
            return Directory.EnumerateDirectories(TextureDir, "*.*", SearchOption.TopDirectoryOnly).Select(dir => new Texture(dir));
        }


        public string ReadText(string fileName)
        {
            string path = Path.Combine(mainDir, $"{fileName}.txt");
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        public void WriteText(string fileName, string text)
        {
            string path = Path.Combine(mainDir, $"{fileName}.txt");
            using StreamWriter stream = File.CreateText(path);
            stream.Write(text);
        }

        public T? ReadJson<T>(string fileName, JsonSerializerOptions? options = null)
        {
            string path = Path.Combine(mainDir, $"{fileName}.json");
            if (File.Exists(path))
            {
                ReadOnlySpan<byte> data = File.ReadAllBytes(path);
                return JsonSerializer.Deserialize<T>(data, options);
            }
            else
            {
                return default;
            }
        }

        public void WriteJson<T>(T value, string fileName, JsonSerializerOptions? options = null)
        {
            string path = Path.Combine(mainDir, $"{fileName}.json");
            using FileStream stream = File.Create(path);
            string json = JsonSerializer.Serialize(value, options);
            stream.Write(Encoding.UTF8.GetBytes(json));
        }
    }
}
