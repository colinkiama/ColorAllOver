using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace ColorAllOver
{
    public class InfluencerBrush
    {
        static Compositor _compositor = Window.Current.Compositor;

        public static void AddInfluencerBrush(Panel panel)
        {
            
            var visual = _compositor.CreateSpriteVisual();
            visual.Brush = CreateInfluencerBrush();

            visual.Size = new System.Numerics.Vector2((float)Window.Current.Bounds.Width, (float)Window.Current.Bounds.Height);
            var container = _compositor.CreateContainerVisual();
            container.Children.InsertAtTop(visual);
            ElementCompositionPreview.SetElementChildVisual(Window.Current.Content,container);
        }
            
        private static CompositionBrush CreateInfluencerBrush()
        {
            Matrix5x4 grayscaleMatrix = CreateGrayscaleMatrix();
            



            ColorMatrixEffect grayscaleMatrixEffect = new ColorMatrixEffect
            {
                ColorMatrix = grayscaleMatrix,
                Source = new CompositionEffectSourceParameter("source")
                

            };

            CompositionEffectFactory grayscaleEffectFactory = _compositor.CreateEffectFactory(grayscaleMatrixEffect);
            var backdropBrush = grayscaleEffectFactory.CreateBrush();
            backdropBrush.SetSourceParameter("source", _compositor.CreateBackdropBrush());


            return backdropBrush;
            
            
        }



        private static Matrix5x4 CreateGrayscaleMatrix()
        {
            // Microsoft official Grayscale
            var matrix = new Matrix5x4
            {
                M11 = 0.333f,
                M12 = 0.333f,
                M13 = 0.333f,
                M14 = 0,
                M21 = 0.333f,
                M22 = 0.333f,
                M23 = 0.333f,
                M24 = 0,
                M31 = 0.333f,
                M32 = 0.333f,
                M33 = 0.333f,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1,
                M51 = 0,
                M52 = 0,
                M53 = 0,
                M54 = 0
            };


            return matrix;
        }

       


    }
}
