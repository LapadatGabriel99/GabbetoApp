   M S B A M L   `   `   `  ���� G  CFasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Fasseto.WordFasseto.Word  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   	Hoverless �� Property �� Value �� 
TargetType �� Padding  SystemIconButton �� BasedOn'   !System.Windows.Shell.WindowChrome  WindowControlButton  	BaseStyle  ForegroundMainBrush �� ScaleX	 �� Triggers
 P� Property P� Value  BackgroundLightBrush  WindowCloseButton  ForegroundLightBrush  WordOrangeBrush 	 FontSizeXXLarge 
 LatoRegular�   �Fasseto.Word.BaseAttachedProperty`2[[Fasseto.Word.IsBusyProperty, Fasseto.Word, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] ��Name �� CornerRadius J� SnapsToDevicePixels �� 	Converter/   )Fasseto.Word.BooleanToVisibilityConverter  SpinningText �� ConverterParameter �� Triggers :� RoutedEvent  WordBlue	 �� To g� Duration �� 
TargetName �� TargetProperty �� From �� 
TargetName  ForegroundDarkBrush  
TextButton  FontSizeLarge  
WordOrange  ForegroundLight  
IconButton  WordBlueBrush  FontAwesome �� RelativeSource  WordLightBlue  ChatPageIconButton  WordTransparentBlueBrush  WordTransparentBlue  ChatPageIconGrowButton J� RenderTransformOrigin 8� X 8� Y	 W� To�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     $localclr-namespace:Fasseto.Word    �� $ Colors.xaml?��� $ 
Fonts.xaml?��� $ 
Texts.xaml?�%�  &	        &	 �     7   &	 �     7  7  7  &	 /    7  7  '�� �    7  7  7  7 	 7 
 7  7  7  7  &	 �    7  7  7  7 
 7  7  7  &	 �    7  7  7  7 	 7  7  7  7  &	 \
    7  7  7  7  7  &	 .    7  7  �� " ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� # z��#��z��._��� $��Center=�$��Center=��� " ��8   .���   �@  IsHitTestVisibleInChrome$
 True����  � ��$ 10q��� " ��8   .���   �@  IsHitTestVisibleInChrome$
 True����  � ��
 ���� ��  � ��$ 8q���  � ��8  ��  � �� �� " ��.R��� # z��#��z��._��� $��Center=�$��Center=�#��z����  �@�LayoutTransform �� $	 1.5Q�	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��8  �� " ��8   	 P� 
 �@J�IsMouseOver$
 True��. ���  � ��
 �  ����  � ��8  �� " ��8   .���  � ��8  ��  � ��8  ��  � ��$ 0q���  � ��8  ��  � ��8  ��  � ��$ 50 10q���  � ��$
 0 10q���  �@ Value$ False����  � �� �� " ��.R��� $ border��$ 10��#��z��#��z��#��z��$
 True��._�� .+��� #��z��$|�False��#��z��#��z��#��z��#��z��# z #��z��y��� *local:IsBusyProperty.Value+   �� 8�� #��z��#��z��#��z��y��� *local:IsBusyProperty.Value+   $
 True�� :� $ 
MouseEnter��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�:� $ 
MouseLeave��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�P� 
 � {�$ False��. ��� $ border��8   � ���� " ��8   .���  � ��
 ���� ��  � ��8  ��  � ��$ 0q���  � ��8  ��  � ��8  ��  � ��$ 50 10q���  � ��$
 0 10q���  � �� �� " ��.R��� $ border��$ 10��#��z��#��z��#��z��$
 True��._��� #��z��$|�False��#��z��#��z��#��z��#��z��# z #��z�� :� $ 
MouseEnter��.[��� .���� .���� 8  $ 0:0:0.3D�$* $(Foreground).(SolidColorBrush.Color)�:� $ 
MouseLeave��.[��� .���� .���� 8  $ 0:0:0.3D�$* $(Foreground).(SolidColorBrush.Color)�P� 
 � {�$ False��. ��� 8   � ���� " ��8   .���  � ��8  ��  � ��8  ��  � ��$ 0q���  � ��8  ��  � ��8  ��  � ��$ 27q���  � ��$ 0q���  � �� �� *ActualHeight+ �� *Self+��  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 True��._�� .+�(� .���� #��z��$|�False��#��z��#��z��#��z��#��z��# z #��z�� :� $ 
MouseEnter��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�:� $ 
MouseLeave��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�P� 
 � {�$ False��. ��� $ border��8   � ���� " ��8   .���  � ��8  ��  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 True��._�� .+�(� .���� #��z��$|�False��#��z��#��z��#��z��#��z��# z #��z�� :� $ 
MouseEnter��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�:� $ 
MouseLeave��.[��� .���� .���� 8  $ 0:0:0.3D�$ border��$ Background.Color�P� 
 � {�$ False��. ��� $ border��8   � ���� " ��8   .���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 True��z���  8� $	 0.5Q�$	 0.5Q�._�� .+�(� .���� #��z��$|�False��#��z��#��z��#��z��#��z��# z #��z�� :� $ 
MouseEnter��.[��� .���� .��W�  1.4$ 0:0:0.15D�$ border��$/ )(RenderTransform).(ScaleTransform.ScaleX)�W�  1.4$ 0:0:0.15D�$ border��$/ )(RenderTransform).(ScaleTransform.ScaleY)�:� $ 
MouseLeave��.[��� .���� .��W�  1$ 0:0:0.3D�$ border��$/ )(RenderTransform).(ScaleTransform.ScaleX)�W�  1$ 0:0:0.3D�$ border��$/ )(RenderTransform).(ScaleTransform.ScaleY)�P� 
 � {�$ False��. ��� $ border��8   � ��