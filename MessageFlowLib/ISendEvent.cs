﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFlowLib
{
	public interface ISendEvent
	{
		void SendEvn(string strEvn,
			object objData);
	}
}
