using AspAdminTemplate.Attributes.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Extenstions
{
	public static class HtmlHelperExtensions
	{
		public static IHtmlContent DisplayAsImage(this IHtmlHelper helper, string BaseUrl, string src, string altText, string height = null, string width = null, string maxheight = null, string maxwidth = null, string cssClass = "", ImageBackground imageBackground = ImageBackground.None)
		{
			var img = new TagBuilder("img") { TagRenderMode = TagRenderMode.SelfClosing };

			#region url
			if (string.IsNullOrWhiteSpace(src))
			{
				src = "/assets/img/NoImage.png";
			}
			else
			if (!string.IsNullOrWhiteSpace(BaseUrl) && !src.Contains("http"))
			{
				src = BaseUrl + src;
			}

			img.MergeAttribute("src", src);
			#endregion

			#region Class
			if (imageBackground == ImageBackground.CheckerBg)
			{
				cssClass += " checker-bg ";
			}

			img.MergeAttribute("class", cssClass);
			#endregion

			img.MergeAttribute("alt", altText);

			if (!string.IsNullOrWhiteSpace(height))
			{
				img.MergeAttribute("height", height);
			}
			if (!string.IsNullOrWhiteSpace(width))
			{
				img.MergeAttribute("width", width);
			}
			if (!string.IsNullOrWhiteSpace(maxheight))
			{
				img.MergeAttribute("max-height", maxheight);
			}
			if (!string.IsNullOrWhiteSpace(maxwidth))
			{
				img.MergeAttribute("max-width", maxwidth);
			}

			string result;

			using (var writer = new StringWriter())
			{
				img.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
				result = writer.ToString();
			}

			return new HtmlString(result);
		}

		public static IHtmlContent DisplayAsGalleryImage(this IHtmlHelper helper, string BaseUrl, string src, string altText, string title = null, string moreInt = null, string cssClass = "", ImageBackground imageBackground = ImageBackground.None)
		{
			var divimg = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };

			#region url
			if (string.IsNullOrWhiteSpace(src))
			{
				src = "/assets/img/NoImage.png";
			}
			else
			if (!string.IsNullOrWhiteSpace(BaseUrl) && !src.Contains("http"))
			{
				src = BaseUrl + src;
			}

			divimg.MergeAttribute("data-image", src);
			#endregion

			#region Class
			if (imageBackground == ImageBackground.CheckerBg)
			{
				cssClass += " checker-bg ";
			}

			if (cssClass.Contains("gallery-more"))
			{
				var child = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
				child.InnerHtml.AppendHtml("+" + moreInt);
				divimg.InnerHtml.AppendHtml(child);
			}

			divimg.MergeAttribute("class", cssClass);
			#endregion

			divimg.MergeAttribute("alt", altText);

			if (!string.IsNullOrWhiteSpace(title))
			{
				divimg.MergeAttribute("data-title", title);
			}


			string result;

			using (var writer = new StringWriter())
			{
				divimg.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
				result = writer.ToString();
			}

			return new HtmlString(result);
		}

	}
}
