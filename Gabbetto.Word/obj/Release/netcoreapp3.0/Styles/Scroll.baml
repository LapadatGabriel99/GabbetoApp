   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBarThumb  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels  WordBlueBrush �� CornerRadius  DarkerScrollBarThumb �� BasedOn  WordDarkBlueBrush  BaseScrollBar �� RelativeSource	 �Name
 �� Padding ]�Name J� IsMouseOver ]� DecreaseRepeatButton J� Opacity �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� Triggers P� Property P� Value �� PageLeftCommand �� PageRightCommand  DarkerScrollBar � ColumnDefinitions � RowDefinitions ��Name ��Name �� CanContentScroll �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4   .System.Windows.Automation.AutomationProperties     AutomationId! � Cursor" �� ScrollableHeight# � Maximum$ � Minimum*% �� #ComputedVerticalScrollBarVisibility& �� ViewportHeight' �� ViewportSize( � Value) �� Mode* �� ScrollableWidth+ �� Orientation,, �� %ComputedHorizontalScrollBarVisibility- �� ViewportWidth. �� Triggers/ :� RoutedEvent	0 W� To1 g� Duration2 �� 
TargetName3 �� TargetProperty  WordLightBlue	4 �� To  WordBlue  DarkerScrollViewer�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     $localclr-namespace:Fasseto.Word  %�  &	        7  &	 �     7   7  &	     7   7   &	     7  7  7  '�� Z    7  7  7  7  7  7  &	 �    7  7  �� "  n�.���  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � �� �� " n�.R��� $ 	rectangle��$
 True��8��  $ 3��#��z��#��z���� "  n�8   .���  � �� �� " n�.R��� $ 	rectangle��$
 True��8�� $ 3��#��z��#��z���� "  ��.���  �@��IsPressAndHoldEnabled$ false����  �@��IsFlicksEnabled$ false����  � ��$ 14����  � ��$ 	-14 0 0 0q���  � �� �� *Width+ �� *Self+��  � �� �� " ��.R�� $	 Bg��$
 true��
������ .+��� $	
 0 4q�._�]� $ 
PART_Track��$
��true��#{�z $��6��$��Center=� �� $ 0Q�#��Z  �� $ 0Q�#��Z  n� 8��   P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��$ 14����  � �� �� *Height+ �� *Self+��  � ��$ 	0 -14 0 0q���  � �� �� " ��.R�� $	 Bg��$
 true��.+�]� $ 
PART_Track��#{�z $��6�� �� $ 0Q�#��Z  �� $ 0Q�#��Z  n� 8�� �� "  ��8   .���  � �� �� " ��.R�� $	 Bg��$
 true��
������ .+��� $	
 0 4q�._�]� $ 
PART_Track��$
��true��#{�z $��6��$��Center=� �� $ 0Q�#��Z  �� $ 0Q�#��Z  n� 8��  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��$ 14����  � �� �� *Height+ �� *Self+��  � ��$ 	0 -14 0 0q���  � �� �� " ��.R�� $	 Bg��$
 true��.+�]� $ 
PART_Track��#{�z $��6�� �� $ 0Q�#��Z  �� $ 0Q�#��Z  n� 8�� �� "  ��.���  � �� �� " ��.R�� $
	 Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $ Corner��$��1��#��� ��$��1���� $! PART_ScrollContentPresenter��# z��$ False��$ False��#��z��#��z��$��0��#��z��$��0���� $ PART_VerticalScrollBar��$  VerticalScrollBar��$! Arrow��$��1��## z" $$ 0Q�$��0��#y�z% #' z& $	 0.2Q�8��  ( �� *VerticalOffset+$) OneWay=� �� *TemplatedParent+�� $ PART_HorizontalScrollBar��$  HorizontalScrollBar��$! Arrow��$��0��## z* $$ 0Q�$+ 
Horizontal=�$��1��#y�z, #' z- $	 0.2Q�8�� ( �� *HorizontalOffset+$) OneWay=� �� *TemplatedParent+. :� $/ 
MouseEnter��.[��� .���� .��W� 0 1$1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Opacity��� 84  $1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Background.Color�W� 0 1$1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Opacity��� 84  $1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Background.Color�:� $/ 
MouseLeave��.[��� .���� .��W� 0 0.2$1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Opacity��� 84  $1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Background.Color�W� 0 0.2$1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Opacity��� 84  $1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Background.Color��� "  ��.���  � �� �� " ��.R�� $
	 Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $ Corner��$��1��#��� ��$��1���� $! PART_ScrollContentPresenter��# z��$ False��$ False��#��z��#��z��$��0��#��z��$��0���� $ PART_VerticalScrollBar��$  VerticalScrollBar��$! Arrow��$��1��## z" $$ 0Q�$��0��#y�z% #' z& $	 0.3Q�8��  ( �� *VerticalOffset+$) OneWay=� �� *TemplatedParent+�� $ PART_HorizontalScrollBar��$  HorizontalScrollBar��$! Arrow��$��0��## z* $$ 0Q�$+ 
Horizontal=�$��1��#y�z, #' z- $	 0.3Q�8�� ( �� *HorizontalOffset+$) OneWay=� �� *TemplatedParent+. :� $/ 
MouseEnter��.[��� .���� .��W� 0 1$1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Opacity�W� 0 1$1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Opacity�:� $/ 
MouseLeave��.[��� .���� .��W� 0 0.3$1 	00:00:0.3D�$2 PART_VerticalScrollBar��$3 Opacity�W� 0 0.3$1 	00:00:0.3D�$2 PART_HorizontalScrollBar��$3 Opacity�