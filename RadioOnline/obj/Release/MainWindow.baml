   M S B A M L   `   `   `  ���� F  BRadioOnline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RadioOnlineRadioOnline      RadioOnline.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:RadioOnline     -     � Title$  Radio Online��$	��500��$	��300�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources    YellowBackground �� Property �� Value  YellowForeground  LinearColor �� 
StartPoint �� EndPoint	 � Offset
 � Color  	Separator �� 
TargetType �� 
TargetType  
PlayButton ��Name �� RadiusX �� RadiusY J� Opacity � Points �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY  
StopButton��%0  &	        &	       &	 V     &	 �     &	 .    &	 �    �� .���  � ��
 � ����� .���  � ��
 � �����  � ��$ 18(��� .���  � �� �� $	 0,0&�$	 1,1&�.��� $		 0.3Q�$
 Black��� $	 1Q�$
 DimGray���� " ��.���  � �� �� $	 0,0&�$	 1,1&�.��� $	 0Q�$
 Orange��� $	 1Q�$
 Black���� " ��.R�� .+��� $
 Rect��$ 25��$ 25��
��� ���$��3��
��� ���$	 0.8Q��  �   ��� ��� @KL $��Center=�$��Center=�
���   �$��3,0,0,0q� P�  �@J�IsMouseOver . . ��� $
 Rect�� � ��
 ��·�P�  � �� . . ���  � z� �� $	 0.9Q�$	 0.9Q���  �@J�RenderTransformOrigin$ 0.5 0.5&��� " ��.R�� .+��� $
 Rect��$ 25��$ 25��
��� ���$��3��
��� ���$	 0.8Q��� 
���   �$��10��$��10��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $
 Rect�� � ��
 ��·�P�  � �� . . ���  � z� �� $	 0.9Q�$	 0.9Q���  �@J�RenderTransformOrigin$ 0.5 0.5&�.��� 
���   � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� �� $��20 �.+��  � ColumnDefinitions �� ��  �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��#��[ .��Radio Online�� $��1�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��20��$��20��$��_��$��5q��� -   $��20��$��20��$��X��$��5q��� $��1��$��2��$	��300��$��2��#��[ � $��1�� �� $
��Auto ��� $
��Auto ���  �� �� .+��� -   $��P��$��40��$��40��$��10q�#��[ �� -   $��1��$��s��$��40��$��40��$��10q�#��[ �� -    ��Name$ SliderVolume��$��2�� � Minimum$ 0Q� � Maximum$ 1Q�$	��100��$��10q��� $��2��
��� ���$��10q�$��volume��$��Center=�$��Bottom=��� -    ��Name$ 
PowerSound��$��2��
��� ���$��50,10q�$��%��$��Right=�$��Bottom=��� $��1��$��3��$	��300��$��2��#��[ r� -   $��mPlayer��$��2��$��0��$��0�� r� LoadedBehavior$ Manual=�  r� UnloadedBehavior$  Manual=�� $��3�� �� $
��Auto ��� $
��Auto ��� �� $
��Auto �.+��� $ 
Horizontal=�.+��� -	   $ 
TitleMusic��
��� ���$��5q��� $��1��$��3��$	��300��$��2��#��[ �� -
   ! ��Name$! ListStations��$��2��#��[ 
��� ���$��0q��� $��3��$��3��$	��300��$��2��#��[ �� $��4��$ 
Horizontal=�.+��� $��State: ��
��� ����� -   $ Status��
��� ���