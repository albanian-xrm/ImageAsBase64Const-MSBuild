/*
   Copyright 2025 AlbanianXrm <albanian@xrm.al>

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.IO;
using System.Security.Cryptography;

namespace AlbanianXrm
{
    public class ImageAsBase64ConstTask : Task
    {
        [Required]
        public string InputFile { get; set; }

        [Required]
        public string IntermediateOutputPath { get; set; }

        public string Namespace { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Output]
        public string OutputFile { get; set; }

        private static readonly ToBase64Transform base64Transform = new ToBase64Transform();
        public override bool Execute()
        {
            FileInfo fileInfo = new FileInfo(InputFile);
            if (fileInfo.Exists == false)
            {
                Log.LogError($"Input file '{InputFile}' does not exist.");
                return false;
            }
            using (var reader = new StreamReader(new CryptoStream(fileInfo.OpenRead(), base64Transform, CryptoStreamMode.Read)))
            {
                OutputFile = Path.Combine(IntermediateOutputPath, $"AlbanianXrm.ImageAsBase64Const_{Namespace}_{ClassName}_{FieldName}.g.cs");
                using (var writer = new StreamWriter(OutputFile, false))
                {
                    if (!string.IsNullOrWhiteSpace(Namespace))
                    {
                        writer.WriteLine($"namespace {Namespace}");
                        writer.WriteLine("{");
                    }
                    writer.WriteLine($"    public static partial class {ClassName}");
                    writer.WriteLine("    {");
                    writer.WriteLine($"        public const string {FieldName} = \"{reader.ReadToEnd()}\";");
                    writer.WriteLine("    }");
                    if (!string.IsNullOrWhiteSpace(Namespace))
                    {
                        writer.WriteLine("}");
                    }
                }
            }
            return true;
        }
    }
}
