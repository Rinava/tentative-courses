using System;

namespace Exercise.Models
{
    public class Level
    {
        public enum _Level
        {
            Beginner,
            Pre_intermediate,
            Intermediate,
            Upper_Intermediate,
            Advanced
        }

        private _Level _level;

        public _Level CurrentLevel
        {
            get
            {
                return _level;
            }
            set
            {
                if (ValidLevel(_level)) { _level = value; }
                else { throw new ArgumentException("Wrong parameter value", nameof(_level)); }
            }
        }

        public static Boolean ValidLevel(_Level _level)
        {
            if (_level == _Level.Beginner || _level == _Level.Pre_intermediate || _level == _Level.Intermediate || _level == _Level.Upper_Intermediate || _level == _Level.Advanced)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}