using System;

namespace Exercise.Models
{
    public class Modality
    {
        public enum _Modality
        {
            Individual,
            Group,
        }

        private _Modality _modality;

        public _Modality CurrentModality
        {
            get
            {
                return _modality;
            }
            set
            {
                if (_modality == _Modality.Individual || _modality == _Modality.Group)
                {
                    CurrentModality = _modality;
                }
                else
                {
                    throw new ArgumentException("Wrong parameter value", nameof(_modality));
                }
            }
        }
    }
}