using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface INowOperator
    {
        public int Get_CurrentYear_Local()
        {
            var nowLocal = this.Get_Now_Local();

            var currentYear = nowLocal.Year;
            return currentYear;
        }

        public int Get_CurrentYear_Utc()
        {
            var nowLocal = this.Get_Now_Utc();

            var currentYear = nowLocal.Year;
            return currentYear;
        }

        /// <summary>
        /// Chooses <see cref="Get_CurrentYear_Local"/> as the default.
        /// </summary>
        public int Get_CurrentYear()
        {
            var currentYear = this.Get_CurrentYear_Local();
            return currentYear;
        }

        /// <inheritdoc cref="IDateTimeOperator.Get_Now_Local"/>
        public DateTime Get_Now_Local()
        {
            var output = Instances.DateTimeOperator.Get_Now_Local();
            return output;
        }

        /// <inheritdoc cref="IDateTimeOperator.Get_Now_Utc"/>
        public DateTime Get_Now_Utc()
        {
            var output = Instances.DateTimeOperator.Get_Now_Utc();
            return output;
        }

        /// <inheritdoc cref="IDateTimeOperator.Get_Now"/>
		public DateTime Get_Now()
        {
            var output = Instances.DateTimeOperator.Get_Now();
            return output;
        }

        public DateTime Get_Today_Local()
        {
            var now = this.Get_Now_Local();

            var output = now.Date;
            return output;
        }

        public DateTime Get_Today_Utc()
        {
            var now = this.Get_Now_Utc();

            var output = now.Date;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        public DateTime Get_Today()
        {
            var output = this.Get_Today_Local();
            return output;
        }
    }
}
