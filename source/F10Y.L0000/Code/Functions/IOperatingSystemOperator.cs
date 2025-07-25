using System;
using System.Runtime.InteropServices;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IOperatingSystemOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Internal.IOperatingSystemOperator _Internal => Internal.OperatingSystemOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public bool Is_CurrentOperatingSystemPlatform(OSPlatform operatingSystemPlatform)
            => RuntimeInformation.IsOSPlatform(operatingSystemPlatform);

        public OSPlatform Get_CurrentOperatingSystemPlatform()
        {
            // Prior work:
            // * R5T.D0024.Default.OSPlatformProvider
            // * R5T.L0066

            // Implementation note: there is no RuntimeInformation.GetOSPlatform() method, so the only way to determine the OSPlatform is to test each one.
            if (this.Is_CurrentOperatingSystemPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows;
            }

            if (this.Is_CurrentOperatingSystemPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX;
            }

            if (this.Is_CurrentOperatingSystemPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux;
            }

            throw _Internal.Get_UnknownOSPlatformException();
        }

        public bool Is_Linux_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.Linux == operatingSystemPlatform;
            return output;
        }

        public bool Is_OSX_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.OSX == operatingSystemPlatform;
            return output;
        }

        public bool Is_Windows_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.Windows == operatingSystemPlatform;
            return output;
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            OSPlatform operatingSystemPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            // Put Linux first, since this is most common in production.
            if (this.Is_Linux_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return linuxValue;
            }

            // Put Windows second, since this is most common in development.
            if (this.Is_Windows_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return windowsValue;
            }

            // Put OSX last, since this is least common.
            if (this.Is_OSX_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return osxValue;
            }

            throw _Internal.Get_UnknownOSPlatformException();
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
           T windowsValue,
           T osxValue,
           T linuxValue)
        {
            var osPlatform = this.Get_CurrentOperatingSystemPlatform();

            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue);
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            T windowsValue,
            T osxValue,
            T linuxValue,
            T unknownValue)
        {
            var osPlatform = this.Get_CurrentOperatingSystemPlatform();

            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue,
                unknownValue);
        }

        public T SwitchOn_OSPlatform_ByValue<T>(
            OSPlatform operatingSystemPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue,
            T unknownValue)
        {
            // Unable to use basic switch statement since OSPlatform values are not constant.
            // Unable to use relational switch statement since it is not available until C# 9.0 (net5.0).

            // Put Linux first, since this is most common in production.
            if (this.Is_Linux_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return linuxValue;
            }

            // Put Windows second, since this is most common in development.
            if (this.Is_Windows_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return windowsValue;
            }

            // Put OSX last, since this is least common.
            if (this.Is_OSX_OperatingSystemPlatform(operatingSystemPlatform))
            {
                return osxValue;
            }

            return unknownValue;
        }
    }
}
