   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5      +    %Fasseto.Word.AddSearchListItemControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5        � 	Resources  5         ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name  ForegroundLightBrush �Name � ColumnDefinitions �� Padding	 �� 	Converter,   &Fasseto.Word.StringRGBToBrushConverter
 �� RelativeSource �� CornerRadius  FontSizeLarge  LatoRegular �� Padding  WordLightBlueBrush  ForegroundDarkBrush ��Name  WordDarkBlueBrush  FontSizeSmall �� Triggers �� Value �� Binding �� 
TargetName  WordVeryLightBlueBrush :� RoutedEvent 	 WordVeryLightBlue	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value��%  &	        7  7  7  7  7  7  7  7  7  7  7  7 	 7  �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
background��6!   8��  ._�5      � $ 	container��6#   
������  5   "   �� 5   &   $
��auto �67   �� 5   &   $��* �67   .+�5   "   �� $��0��6)   $
 8 15q�5    )   ._�5#   &   �� $��40��5&   -   ��5#   -   �� *ProfilePictureRGB+	   ��5$   -   �� *ActualHeight+
 �� *Self+ 5%   -   �� *ActualHeight+
 �� *Self+._�5(   *   �� $��Center=�5)   4   $��Center=�5*   4   8�� 8�� 8�� ��5(   4   �� *
Initials+5-   4   5.   '   5/   #   �� 52   "   $��1��6)   $ 0 0 15 0q�69   ._�53   &   �� $��Center=�61   .+�55   *   �� $ 0 0 0 2q�56   4   8�� 8�� $��CharacterEllipsis=�59   4   $
��Left=�5:   4   ��55   4   �� *NameAndUserName+5:   4   � 5<   *   $��0 4 0 -4q�6/    5=   .   �� 5>   2   $��* �6C   �� 5?   2   $
��Auto �6C   .+�5C   .   �� $ 0 3 0 0q�5D   8   8�� 8�� $��CharacterEllipsis=�5G   8   $��Center=�5H   8   ��5C   8   �� *Description+5H   8   �� 5J   .   $	 add��5S   5   $��1��5J   5   8�� $	��Add��5L   5   8��	 $��Right=�5N   5   $��0 0 0 0q�5O   5   $��0q�5P   5   $��30��5Q   5   $	��100��5R   5   5S   5   5U   +   5X   '   5Y   #   5Z      5[       5]      �� 5^      $
 True��6I    6*   �� *
IsSelected+.a�5_   "   �� $ 
background��6?   8 
  � ��6W   5`      :� 5b      $ 
MouseEnter��6+   .[�5c   "   �� .��5d   &   �� .��5e   *   �� 8  $ 0:0:0.3D�6a   $ 	container��6t   $ Background.Color�6�   5f   '   5g   #   5h      :� 5j      $ 
MouseLeave��6+   .[�5k   "   �� .��5l   &   �� .��5m   *   ��  Transparent69   $ 0:0:0.3D�6J   $ 	container��6]   $ Background.Color�6   5n   '   5o   #   5p      P� 5r       � {�$ False��6;   . �5s   "   �� $ 	container��6?   8   � ��6V   5t      5v      5x      5y      5z      .��5|      �� -   5         ��Name$ contentControl��5~      #��[  5}      5~      5�      