

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace TheSystemOf3S
{
	public sealed class RemoveLayer : BaseCommand  
	{
		private IMapControl3 m_mapControl;

		public RemoveLayer()
		{
			base.m_caption = "�Ƴ�ͼ��";
		}
	
		public override void OnClick()
		{
			ILayer layer =  (ILayer) m_mapControl.CustomProperty;
			m_mapControl.Map.DeleteLayer(layer);
		}
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}

	}
}


