   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5      &     Fasseto.Word.ChatListItemControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5        � 	Resources  5         ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name  ForegroundLightBrush J� InputBindings d� MouseAction �� Command	 �Name
 � ColumnDefinitions �� 	Converter/   )Fasseto.Word.BooleanToVisibilityConverter �� ConverterParameter �� Padding,   &Fasseto.Word.StringRGBToBrushConverter �� RelativeSource �� CornerRadius  FontSizeLarge  LatoRegular �� Padding  WordLightBlueBrush  ForegroundDarkBrush �� Triggers �� Value �� Binding �� 
TargetName  WordVeryLightBlueBrush :� RoutedEvent  WordVeryLightBlue	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value��%i  &	        7  7  7  7  7  7  7  7  7  7  7  �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
background��6!   8��   5      d� 5   "   $ 	LeftClicke�6/    6G   �� *OpenMessageCommand+._�5      � $	 	container��6#   
������ 
 5   "   �� 5   &   $
��auto �67   �� 5   &   $��* �67   .+�5#   "   �� 
���  ��$��4��6:   $
��Left=�5$   %   y�5%   %   �� *NewContentAvailable+   $
 True���� 5)   "   $��0��6)   $
 8 15q�5*   )   ._�5-   &   �� $��40��50   -   ��5-   -   �� *ProfilePictureRGB+   ��5.   -   �� *ActualHeight+ �� *Self+ 5/   -   �� *ActualHeight+ �� *Self+._�52   *   �� $��Center=�53   4   $��Center=�54   4   8�� 8�� 8�� ��52   4   �� *
Initials+57   4   58   '   59   #   �� 5<   "   $��1��6)   $ 0 0 15 0q�69   ._�5=   &   �� $��Center=�61   .+�5?   *   �� $ 0 0 0 2q�5@   4   8�� 8�� $��CharacterEllipsis=�5C   4   ��5?   4   �� *Name+5C   4   �� 5E   *   $ 0 2 0 0q�5F   4   8�� 8�� $��CharacterEllipsis=�5I   4   ��5E   4   �� *	Message+5I   4   5J   '   5K   #   5L      5M       5O      �� 5P      $
 True��6I    6*   �� *
IsSelected+.a�5Q   "   �� $ 
background��6?   8   � ��6W   5R      :� 5S      $ 
MouseEnter��6+   .[�5T   "   �� .��5U   &   �� .��5V   *   �� 8 	 $ 0:0:0.3D�6a   $ 	container��6t   $ Background.Color�6�   5W   '   5X   #   5Y      :� 5Z      $ 
MouseLeave��6+   .[�5[   "   �� .��5\   &   �� .��5]   *   ��  Transparent69   $ 0:0:0.3D�6J   $ 	container��6]   $ Background.Color�6   5^   '   5_   #   5`      P� 5a       � {�$ False��6;   . �5b   "   �� $ 	container��6?   8 
  � ��6V   5c      5e      5g      5h      5i      .��5k      �� #��[  5l      5n      