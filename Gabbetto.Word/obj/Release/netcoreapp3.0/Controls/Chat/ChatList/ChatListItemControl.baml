   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core &     Fasseto.Word.ChatListItemControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Fasseto.Word     Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core       � 	Resources     ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name  ForegroundLightBrush J� InputBindings d� MouseAction �� Command	 �Name
 � ColumnDefinitions �� 	Converter/   )Fasseto.Word.BooleanToVisibilityConverter �� ConverterParameter �� Padding,   &Fasseto.Word.StringRGBToBrushConverter �� RelativeSource �� CornerRadius  FontSizeLarge  LatoRegular �� Padding  WordLightBlueBrush  ForegroundDarkBrush �� Triggers �� Value �� Binding �� 
TargetName  WordVeryLightBlueBrush :� RoutedEvent  WordVeryLightBlue	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value��%t  &	        7  7  7  7  7  7  7  7  7  7  7  �� " ��.���  � �� �� " ��.R��� $ 
background��8��   d� $ 	LeftClicke� �� *OpenMessageCommand+._�� $	 	container��
������ 
 �� $
��auto ��� $��* �.+��� 
���  ��$��4��$
��Left=�y��� *NewContentAvailable+   $
 True���� $��0��$
 8 15q�._��� $��40������ *ProfilePictureRGB+   ���� *ActualHeight+ �� *Self+ �� *ActualHeight+ �� *Self+._��� $��Center=�$��Center=�8�� 8�� 8�� ���� *
Initials+�� $��1��$ 0 0 15 0q�._��� $��Center=�.+��� $ 0 0 0 2q�8�� 8�� $��CharacterEllipsis=����� *Name+�� $ 0 2 0 0q�8�� 8�� $��CharacterEllipsis=����� *	Message+ �� $
 True�� �� *
IsSelected+.a��� $ 
background��8   � ��:� $ 
MouseEnter��.[��� .���� .���� 8 	 $ 0:0:0.3D�$ 	container��$ Background.Color�:� $ 
MouseLeave��.[��� .���� .����  Transparent$ 0:0:0.3D�$ 	container��$ Background.Color�P�  � {�$ False��. ��� $ 	container��8 
  � ��.���� #��[  