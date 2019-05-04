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

namespace ColorAllOver
{
    public class InfluencerBrush
    {
        static Compositor _compositor = Window.Current.Compositor;

        public static void AddInfluencerBrush()
        {
            var visual = _compositor.CreateSpriteVisual();
            visual.Brush = CreateInfluencerBrush();
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
            var grayscaleBrush = grayscaleEffectFactory.CreateBrush();
            var backdropBrush = _compositor.CreateBackdropBrush();
            grayscaleBrush.SetSourceParameter("source", backdropBrush);
            return backdropBrush;
            
            
        }

        private static Matrix5x4 CreateGrayscaleMatrix()
        {
            var matrix = new Matrix5x4();
            matrix.M11 = 0.33f;
            matrix.M12 = 0.33f;
            matrix.M13 = 0.33f;
            matrix.M14 = 0;


            matrix.M21 = 0.59f;
            matrix.M22 = 0.59f;
            matrix.M23 = 0.59f;
            matrix.M24 = 0;

            matrix.M31 = 0.11f;
            matrix.M32 = 0.11f;
            matrix.M33 = 0.11f;
            matrix.M34 = 0;

            return matrix;
        }

        private static Matrix5x4 CreateBlackAndWhiteMatrix()
        {
            var matrix = new Matrix5x4();
            
            matrix.M11 = 1.5f;
            matrix.M12 = 1.5f;
            matrix.M13 = 1.5f;
            matrix.M14 = 0;


            matrix.M21 = 1.5f;
            matrix.M22 = 1.5f;
            matrix.M23 = 1.5f;
            matrix.M24 = 0;

            matrix.M31 = 1.5f;
            matrix.M32 = 1.5f;
            matrix.M33 = 1.5f;
            matrix.M34 = 0;

            matrix.M51 = -1;
            matrix.M52 = -1;
            matrix.M53 = -1;
            matrix.M54 = 1;

            return matrix;
        }


    }
}
