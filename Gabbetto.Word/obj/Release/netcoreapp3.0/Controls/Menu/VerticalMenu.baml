   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core     Fasseto.Word.VerticalMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Fasseto.Word     Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     .���� 
����������� *Items+���� .R�� .+�� y��� *Type+  �� 	Converter  2   ,Fasseto.Word.MenuItemTypeVisibilityConverter   �� ConverterParameter$ Header��.+��� $	��0.5��   ForegroundDarkBrush#��[  ��   LatoRegular#��[   FontSizeSmall#��[  �� Padding$ 0 5 10 5q�$
��Left=�  ForegroundLightBrush#��[   WordDarkBlueBrush#��[ ���� *Text+�� #��[  �� CornerRadius$ 8�� � Cursor$
 Hand�� �� Padding$ 5q�y��� *Type+    $ TextAndIcon�� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .����   WordLightBlue	 �� To# [ 	 g� Duration$	 00:00:00.05D�
 �� TargetProperty$
 Background.Color���   ForegroundLight# [ $	 00:00:00.05D�$
 Foreground.Color� �� 
TargetName$
 icon���� # [ $	 00:00:00.05D�$
 Foreground.Color�$
 text��:� $ 
MouseLeave��.[��� .���� .���� # [ $	 00:00:00.05D�$
 Background.Color���   ForegroundDark# [ $	 00:00:00.05D�$
 Foreground.Color�$
 icon����   ForegroundVeryDark# [ $	 00:00:00.05D�$
 Foreground.Color�$
 text��._��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $
��icon��$ 5q� 	 FontAwesome#��[	 #��[  ���� *Icon+  1   +Fasseto.Word.IconTypeToFontAwesomeConverter  �� $
��text��$��2��$��5 0 5 0q�$��Center=�#��[  
 ForegroundVeryDarkBrush#��[
 ���� *Text+