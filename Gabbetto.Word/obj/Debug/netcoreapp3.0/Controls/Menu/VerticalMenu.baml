   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5          Fasseto.Word.VerticalMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5      .��5
      �� 
���������5      �� *Items+��5   
   �� 5      .R�5      � .+�5      � y�6   �� *Type+  �� 	Converter  2   ,Fasseto.Word.MenuItemTypeVisibilityConverter   �� ConverterParameter$ Header��.+�5      �� $	��0.5��6!      ForegroundDarkBrush#��[  6.   �� 5        LatoRegular#��[ 5   $     FontSizeSmall#��[ 5   $    �� Padding$ 0 5 10 5q�5   $   $
��Left=�5   $     ForegroundLightBrush#��[ 5    $     WordDarkBlueBrush#��[ 5!   $   ��5   $   �� *Text+5!   $   5#      �� 5&      #��[ 6    �� CornerRadius$ 8��5'       � Cursor$
 Hand��5(       �� Padding$ 5q�5)      y�5*      �� *Type+    $ TextAndIcon�� � Triggers 5,      :� 5-       :� RoutedEvent$ 
MouseEnter��6+   .[�5.   "   �� .��5/   &   �� .��50   *   ��   WordLightBlue	 �� To# [ 69   	 g� Duration$	 00:00:00.05D�51   9   
 �� TargetProperty$
 Background.Color�52   9   �� 53   *     ForegroundLight# [ 69   $	 00:00:00.05D�54   9   $
 Foreground.Color�55   9    �� 
TargetName$
 icon��56   9   �� 57   *   # [ 69   $	 00:00:00.05D�58   9   $
 Foreground.Color�59   9   $
 text��5:   9   5;   '   5<   #   5=      :� 5>      $ 
MouseLeave��6+   .[�5?   "   �� .��5@   &   �� .��5A   *   �� # [ 69   $	 00:00:00.05D�5B   8   $
 Background.Color�5C   8   �� 5D   *     ForegroundDark# [ 69   $	 00:00:00.05D�5E   9   $
 Foreground.Color�5F   9   $
 icon��5G   9   �� 5H   *     ForegroundVeryDark# [ 69   $	 00:00:00.05D�5I   9   $
 Foreground.Color�5J   9   $
 text��5K   9   5L   '   5M   #   5N      ._�5R      �  � ColumnDefinitions 5S      �� 5U   "   $
��Auto �63   �� 5W   "   $��* �63   .+�5[      �� $
��icon��6(   $ 5q�5\   (    	 FontAwesome#��[	 5]   (   #��[  5_   (   ��5^   (   �� *Icon+  1   +Fasseto.Word.IconTypeToFontAwesomeConverter  5_   (   �� 5b      $
��text��5c   (   $��2��5b   (   $��5 0 5 0q�5d   (   $��Center=�5f   (   #��[ 5g   (    
 ForegroundVeryDarkBrush#��[
 5h   (   ��5e   (   �� *Text+5h   (   5j      5l      5n      5p      5s      5t      