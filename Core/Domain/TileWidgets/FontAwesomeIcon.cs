using System;

namespace Core.Domain.TileWidgets
{
    public class FontAwesomeIcon : ValueObject<FontAwesomeIcon>
    {
        public static string StickyNote = "fa fa-sticky-note";

        public string Name { get; set; }

        public FontAwesomeIcon()
        {
            
        }

        public FontAwesomeIcon(string name)
        {
            Name = name;
        }

        protected override bool EqualsCore(FontAwesomeIcon comparedIcon)
        {
            if (comparedIcon.Name == Name)
            {
                return true;
            }
            return false;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Convert.ToInt32(Name);
                hashCode = (hashCode * 397) ^ Convert.ToInt32(Name);
                return hashCode;
            }
        }
    }
}
