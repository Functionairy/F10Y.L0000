using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOperator
    {
        public DateTime Get_Now_Local()
        {
            var output = DateTime.Now;
            return output;
        }

        public DateTime Get_Now_Utc()
        {
            var output = DateTime.UtcNow;
            return output;
        }

        /// <summary>
		/// Chooses <see cref="Get_Now_Local"/> as the default.
		/// </summary>
		public DateTime Get_Now()
        {
            var output = this.Get_Now_Local();
            return output;
        }

        public int Get_Year(DateTime dateTime)
        {
            var output = dateTime.Year;
            return output;
        }
    }
}
