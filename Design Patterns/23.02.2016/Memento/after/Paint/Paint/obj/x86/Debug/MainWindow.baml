   M S B A M L   `   `   `  ����@  <Paint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PaintPaint  5   @       Paint.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   %Paintclr-namespace:Paint     6@   -   5          �Name$  window��5   	    � Title$ 
MainWindow��5   b   $	��520��6u   $	��520��6�   .��5      � $	��500��6   $	��500��6    � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��100 �6   .+�5
   
      Paint.InkCanvasWithUndo  -   5          Name$ InkCanvasWithUndo1��5
   L   $
��Auto��6"   $
��Left=�60   $	��Top=�6h   $
��Auto��6�   $��0��6�   �� 5   
   $��28��6   $��Right=�6   $��0,0,0,0q�68   $	��Top=�6I   $��38��6a   $��1��6l   ��6|   �� *Count+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      5      