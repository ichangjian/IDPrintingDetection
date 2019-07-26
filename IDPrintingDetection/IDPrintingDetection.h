#pragma once

using namespace System;

namespace IDPrintingDetection {
	public ref class IDPD
	{
	public:
		int sum(int x, int y);
		int setStImage(IntPtr data, int width, int height);
		int setShImage(IntPtr data, int width, int height);
	};
}
