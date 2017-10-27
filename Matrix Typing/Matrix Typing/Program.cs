using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_Typing
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            typewriting( "Wake up Neo" );
            typewriting( "The Matrix has you..." );
            typewriting( "Follow the white rabbit..." );
            typewriting( "Knock knock Neo." );

        }
        static void typewriting( String word )
        {
            for ( int i = 0; i < word.Length; i++ )
            {
                Console.Write( word.ElementAt( i ) );
                Console.CursorVisible = true;
                System.Threading.Thread.Sleep( 50 );
            }
            System.Threading.Thread.Sleep( 5000 );
            Console.Clear();
        }
        static T input<T>( string prompt )
        {
            T Response;
            typewriting( prompt );

            return Response = TryParse<T>( Console.ReadLine() );
        }
        static S TryParse<S>( object readline )
        {
            try
            {
                return (S) Convert.ChangeType( readline, typeof( S ) );
            }
            catch ( Exception jackLame )
            {
                MessageBox.Show( $"{jackLame}" );
                return default( S );
            }
        }
    }
}
