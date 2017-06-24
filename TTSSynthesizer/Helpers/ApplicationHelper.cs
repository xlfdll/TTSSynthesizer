﻿using System.Reflection;
using System.Windows;

using Xlfdll.Core.Diagnostics;

namespace TTSSynthesizer
{
	public static class ApplicationHelper
	{
		static ApplicationHelper()
		{
			ApplicationHelper.Metadata = new AssemblyMetadata(Assembly.GetExecutingAssembly());
		}

		public static AssemblyMetadata Metadata { get; }

		public static MainWindow MainWindow => Application.Current.MainWindow as MainWindow;
	}
}