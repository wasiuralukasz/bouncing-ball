   M S B A M L   `   `   `  ���� H  DBouncing-ball, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bouncing_ballBouncing_ball      Bouncing_ball.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Bouncing_ball     -     � Title$  Bouncing Ball��$	��760��$
��1280��.���  � ColumnDefinitions �� $	��33* ��� $��6* �.+��� -   $��MyCanvas��$��0��$
��1000��$	��600��$��28,72,28,72q����	#FFF1F1F1.+��� -   $��CanvasBorder��
���   �$��1q�$	��600��$
��1000��$y�Hidden=��� $��1��$��Szerokość okna:��$
��Left=�$��26��$��	10,74,0,0q�$	��Top=�$	��124��$��0,5,5,5q� � IsSharedSizeScope$
 True���� -   $��CanvasWidthInput��$��1��$
��Left=�$��
10,105,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��150��$��25���� $��1��$��Wysokość okna:��$
��Left=�$��26��$��
10,135,0,0q�$	��Top=�$	��124��$��0,5,5,5q�$
 True���� -   $��CanvasHeightInput��$��1��$
��Left=�$��
10,166,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��150��$��24���� $��1��$��Kolor tła:��$
��Left=�$��26��$��
10,195,0,0q�$	��Top=�$	��124��$��0,5,5,5q�$
 True���� $��1��$
��Left=�$��
10,225,0,0q�$	��Top=�$	��150��.@���  �� 
IsSelected$
 true��.��Biały�� .��Szary�� $��1��$��Kolor kuli:��$
��Left=�$��27��$��
10,252,0,0q�$	��Top=�$	��124��$��0,5,5,5q�$
 True���� $��1��$
��Left=�$��
10,283,0,0q�$	��Top=�$	��150��.@��� $
 true��.��Czarny�� .��	Niebieski�� .��
Czerwony�� $��1��$��Prędkość kuli:��$
��Left=�$��26��$��
10,311,0,0q�$	��Top=�$	��124��$��0,5,5,5q�$
 True���� -   $��BallSpeedSlider��$��1��$
��Left=�$��
10,341,0,0q�$	��Top=�$	��150�� � Value$ 50Q� � Minimum$ 1Q� � Maximum$	 200Q� �� IsSnapToTickEnabled$
 True��	 �� TickFrequency$	 1Q��� -   $��1��$��Zastosuj��$
��Left=�$��
10,571,0,0q�$	��Top=�$	��150��$��25���� -   $��1��$��Start��$
��Left=�$��
10,610,0,0q�$	��Top=�$	��150��$��25�����	#FF53E283�� -	   $��1��$
��Stop��$
��Left=�$��
10,647,0,0q�$	��Top=�$	��150��$��25�����	#FFF56868�� -
   $��CanvasBorderCheckBox��$��1��$$��Obramowanie obszaru
roboczego��$
��Left=�$��
10,375,0,0q�$	��Top=�$��32��