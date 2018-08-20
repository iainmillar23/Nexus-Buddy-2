using Firaxis.Framework.Granny;
using System;
using System.ComponentModel;
using System.Drawing.Design;
namespace NexusBuddy
{
	internal class IndieLeaderGlassShader : IndieMaterial
	{
		[Category("Leaderhead Materials"), DisplayName("NormalMap"), Editor(typeof(FilteredFileNameEditor), typeof(UITypeEditor))]
		public string NormalMap
		{
			get
			{
                return ShaderUtils.trimPathFromFilename(base.GetMaterial().FindParameterSet("Civ5LeaderheadTextures").GetParameterValue("NormalMap") as string);
			}
			set
			{
				base.GetMaterial().FindParameterSet("Civ5LeaderheadTextures").SetParameterValue("NormalMap", value.Substring(value.LastIndexOf("\\") + 1));
			}
		}
		[Category("Leaderhead Materials"), DisplayName("IrradianceMap"), Editor(typeof(FilteredFileNameEditor), typeof(UITypeEditor))]
		public string IrradianceMap
		{
			get
			{
                return ShaderUtils.trimPathFromFilename(base.GetMaterial().FindParameterSet("Civ5LightingTextures").GetParameterValue("IrradianceMap") as string);
			}
			set
			{
				base.GetMaterial().FindParameterSet("Civ5LightingTextures").SetParameterValue("IrradianceMap", value.Substring(value.LastIndexOf("\\") + 1));
			}
		}
		[Category("Leaderhead Materials"), DisplayName("EnvironmentMap"), Editor(typeof(FilteredFileNameEditor), typeof(UITypeEditor))]
		public string EnvironmentMap
		{
			get
			{
                return ShaderUtils.trimPathFromFilename(base.GetMaterial().FindParameterSet("Civ5LightingTextures").GetParameterValue("EnvironmentMap") as string);
			}
			set
			{
				base.GetMaterial().FindParameterSet("Civ5LightingTextures").SetParameterValue("EnvironmentMap", value.Substring(value.LastIndexOf("\\") + 1));
			}
		}
        public IndieLeaderGlassShader(IGrannyMaterial material) : base(material)
		{
		}
		public void CopyTextures(string outputFolder)
		{
			base.CopyTextureIfExists(this.NormalMap, outputFolder);
			base.CopyTextureIfExists(this.IrradianceMap, outputFolder);
			base.CopyTextureIfExists(this.EnvironmentMap, outputFolder);
		}
	}
}