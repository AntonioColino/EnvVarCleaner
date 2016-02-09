// ***********************************************************************
// Assembly         : EnvCleanerUI
// Author           : Antonio (Joe) Colino
// Created          : 02-06-2016
//
// Last Modified By : Antonio (Joe) Colino
// Last Modified On : 02-09-2016
// ***********************************************************************
// <copyright file="FlipConverter.cs" company="RegularJoeSoftware">
//     Copyright ©  2016
// </copyright>
// <summary>
// THIS CODE AND INFORMATION IS PROVIDED \"AS IS\" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
// </summary>
// ***********************************************************************
namespace EnvCleanerUI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Class FlipConverter.
    /// </summary>
    public class FlipConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var str = value as string;
            if( str != null ){
                var mybool = bool.Parse( str );
                mybool = !mybool;
                if( targetType == typeof( string ) ) { return mybool.ToString( ); }
                if( targetType == typeof( bool ) ) { return mybool; }
            }

            if( value is bool ){
                var mybool = (bool)value;
                mybool = !mybool;
                if( targetType == typeof( string ) ) { return mybool.ToString( ); }
                if( targetType == typeof( bool ) ) { return mybool; }
            }

            return null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var str = value as string;
            if( str != null ){
                var mybool = bool.Parse( str );
                mybool = !mybool;
                if( targetType == typeof( string ) ) { return mybool.ToString( ); }
                if( targetType == typeof( bool ) ) { return mybool; }
            }

            if( value is bool ){
                var mybool = (bool)value;
                mybool = !mybool;
                if( targetType == typeof( string ) ) { return mybool.ToString( ); }
                if( targetType == typeof( bool ) ) { return mybool; }
            }

            return null;
        }
    }
}