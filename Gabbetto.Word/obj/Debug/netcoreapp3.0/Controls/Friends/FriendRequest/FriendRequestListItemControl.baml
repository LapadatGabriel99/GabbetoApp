   M S B A M L   `   `   `  ����G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  5      L HFasseto.Word.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.CoreFasseto.Word.Core 5      /    )Fasseto.Word.FriendRequestListItemControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Fasseto.Word     5      Kcore:clr-namespace:Fasseto.Word.Core;assembly=Fasseto.Word.Core     5        � 	Resources  5         ContentStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name  ForegroundLightBrush �Name � ColumnDefinitions �� Padding	 �� 	Converter,   &Fasseto.Word.StringRGBToBrushConverter
 �� RelativeSource �� CornerRadius  FontSizeLarge  LatoRegular �� Padding  WordLightBlueBrush ��Name  WordGreenBrush  FontSizeSmall  WordRedBrush �� Triggers �� Value �� Binding �� 
TargetName  WordVeryLightBlueBrush :� RoutedEvent 	 WordVeryLightBlue	 �� To g� Duration �� 
TargetName �� TargetProperty P� Property P� Value 
 ForegroundDarkBrush��%-  &	        7  7  7  7  7  7  7  7  7  7  7  7 	 7 
 �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
background��6!   8��  ._�5      � $ 	container��6#   
������  5   "   �� 5   &   $
��auto �67   �� 5   &   $��* �67   .+�5   "   �� $��0��6)   $
 8 15q�5    )   ._�5#   &   �� $��40��5&   -   ��5#   -   �� *ProfilePictureRGB+	   ��5$   -   �� *ActualHeight+
 �� *Self+ 5%   -   �� *ActualHeight+
 �� *Self+._�5(   *   �� $��Center=�5)   4   $��Center=�5*   4   8�� 8�� 8�� ��5(   4   �� *
Initials+5-   4   5.   '   5/   #   �� 52   "   $��1��6)   $ 0 0 15 0q�69   ._�53   &   �� $��Center=�61   .+�55   *   �� $ 0 0 0 6q�56   4   8�� 8�� $��CharacterEllipsis=�59   4   $��Center=�5:   4   ��55   4   �� *NameAndUserName+5:   4   � 5;   *    5<   .   �� 5=   2   $��* �6C   �� 5>   2   $��* �6C   .+�5A   .   �� $ accept��5J   5   $��0��5A   5   8�� $��Accept��5C   5   8�� $
��Left=�5E   5   $��0q�5F   5   $��30��5G   5   $	��100��5H   5   $��10 0 0 0q�5I   5   5J   5   �� 5M   .   $ decline��5V   5   $��1��5M   5   8�� $��Decline��5O   5   8��	 $��Right=�5Q   5   $��0q�5R   5   $��30��5S   5   $	��100��5T   5   $��0 0 0 0q�5U   5   5V   5   5X   +   5Y   '   5Z   #   5[      5\       5^      �� 5_      $
 True��6I    6*   �� *
IsSelected+.a�5`   "   �� $ 
background��6?   8 
  � ��6W   5a      :� 5c      $ 
MouseEnter��6+   .[�5d   "   �� .��5e   &   �� .��5f   *   �� 8  $ 0:0:0.3D�6a   $ 	container��6t   $ Background.Color�6�   5g   '   5h   #   5i      :� 5k      $ 
MouseLeave��6+   .[�5l   "   �� .��5m   &   �� .��5n   *   ��  Transparent69   $ 0:0:0.3D�6J   $ 	container��6]   $ Background.Color�6   5o   '   5p   #   5q      P� 5s       � {�$ False��6;   . �5t   "   �� $ 	container��6?   8   � ��6V   5u      5w      5y      5z      5{      .��5}      �� #��[  5~      5      