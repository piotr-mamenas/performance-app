using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public static class MimeType
    {
        private static IDictionary<string, string> _knownTypes;

        public static IDictionary<string, string> KnownTypes
        {
            get
            {
                if (_knownTypes == null)
                {
                    _knownTypes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        {".csv","text/csv"},
                        {".doc","application/msword"},
                        {".docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                        {".gif", "image/gif"},
                        {".jpeg", "image/jpeg"},
                        {".jpg", "image/jpeg"},
                        {".rar", "application/x-rar-compressed"},
                        {".pdf", "application/pdf" },
                        {".png", "image/png"},
                        {".xls", "application/vnd.ms-excel"},
                        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                        {".zip", "application/zip"},
                        {".7z", "application/x-7z-compressed"}
                    };
                }
                return _knownTypes;
            }
        }

        public static IEnumerable<string> KnownDocumentTypeExtensions
        {
            get
            {
                return KnownTypes.Keys
                    .Where(key => key.Contains(".doc"))
                    .Where(key => key.Contains(".docx"))
                    .Where(key => key.Contains(".xls"))
                    .Where(key => key.Contains(".xlsx"))
                    .Where(key => key.Contains(".pdf"))
                    .ToList();
            }
        }
    }
}
