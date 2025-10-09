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


        bool Is_CurrentOperatingSystemPlatform(OSPlatform operatingSystemPlatform)
            => RuntimeInformation.IsOSPlatform(operatingSystemPlatform);

        OSPlatform Get_CurrentOperatingSystemPlatform()
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

        bool Is_Linux_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.Linux == operatingSystemPlatform;
            return output;
        }

        bool Is_OSX_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.OSX == operatingSystemPlatform;
            return output;
        }

        bool Is_Windows_OperatingSystemPlatform(OSPlatform operatingSystemPlatform)
        {
            var output = OSPlatform.Windows == operatingSystemPlatform;
            return output;
        }

        T SwitchOn_OSPlatform<T>(
            Func<T> windowsFunction,
            Func<T> nonWindowsFunction)
        {
            var output = this.SwitchOn_OSPlatform(
                windowsFunction,
                nonWindowsFunction,
                nonWindowsFunction);

            return output;
        }

        T SwitchOn_OSPlatform<T>(
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            var osPlatform = this.Get_CurrentOperatingSystemPlatform();

            var output = this.SwitchOn_OSPlatform(
                osPlatform,
                windowsFunction,
                osxFunction,
                linuxFunction);

            return output;
        }

        T SwitchOn_OSPlatform<T>(
            OSPlatform osPlatform,
            Func<T> windowsFunction,
            Func<T> osxFunction,
            Func<T> linuxFunction)
        {
            var function = this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsFunction,
                osxFunction,
                linuxFunction);

            var output = function();
            return output;
        }

        T SwitchOn_OSPlatform_ByValue<T>(
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

        T SwitchOn_OSPlatform_ByValue<T>(
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

        T SwitchOn_OSPlatform_ByValue<T>(
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

        T SwitchOn_OSPlatform_ByValue<T>(
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

        T SwitchOn_OSPlatform<T>(
            T windowsValue,
            T nonWindowsValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                windowsValue,
                nonWindowsValue,
                nonWindowsValue);
        }

        T SwitchOn_OSPlatform<T>(
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                windowsValue,
                osxValue,
                linuxValue);
        }

        // Prior work: R5T.D0025.Default.OSPlatformSwitch and R5T.D0025.Base.IOSPlatformSwitchExtensions.
        T SwitchOn_OSPlatform<T>(
            OSPlatform osPlatform,
            T windowsValue,
            T osxValue,
            T linuxValue)
        {
            return this.SwitchOn_OSPlatform_ByValue(
                osPlatform,
                windowsValue,
                osxValue,
                linuxValue);
        }
    }
}
