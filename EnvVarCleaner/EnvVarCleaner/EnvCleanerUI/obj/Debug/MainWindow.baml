   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   G CEnvCleanerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EnvCleanerUIEnvCleanerUI 5   	      EnvCleanerUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7core&clr-namespace:System;assembly=mscorlib     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ,localclr-namespace:EnvCleanerUI     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  MyWindow��5   	    � Title$ 
MainWindow��5	   	   $	��972��5
   	   $	��615��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�5   	    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   MyEffect   
BlurRadius   	Direction   ShadowDepth   Color  FocusVisual	 �� Property
 �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  EnvButtonStyle �� 
TargetType �� 
TargetType ��Name �� CornerRadius J� Effect'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup ��Name � UseLayoutRounding �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 Z     &	     &	 3    &	 V    &	 w    &	 �    &	 �    &	 �    &		     &	
 $    &	 G    7  7  7  7  7  7  7  7  7 	 7 
   5   
   $ 5Q�5      $	 -45Q�5      $ 7Q�5      $ #B4B2B2��5      �� 5   
   .�5      �� 	 � ��
 5      �� 5      .R�5      �� $��2q�6$    . #��� ��5   $   $	 1 2R�5   $   $��1��5   $   5      5       5!      �� 5"   
   $ 	#FFDDDDDD��6;   �� 5#   
   $ 	#FF707070��67   �� 5$   
   $ #E0FDBE��6>   �� 5%   
   $ 	#FFB1A63C��6:   �� 5&   
   $ #F6C4C6��6<   �� 5'   
   $ 	#FF8B4A2C��68   �� 5(   
   $ 	#FFF4F4F4��6=   �� 5)   
   $ 	#FFADB2B5��69   �� 5*   
   $ 	#FF838383��6=   �� 5+   
   " ��6'   .�5,      �� 	 � ��8
   6+   �� 5-      	 � ��8
  6,   �� 5.      	 � ��$
 1q�60   �� 5/      	 �@�FocusVisualStyle8
  61   �� 50      	 � ��#
 � ��6+   �� 51      	 � ��$
 Center=�6;   �� 52      	 � ��$
 1q�6(   �� 53      	 � ��
 54      �� 55      " ��6&   .R�56      �� $ border��6!   #��z��57   !   #��z��58   !   $��1q�59   !   $ 5��5:   !   # �   5;   !    .  5=        5>   "   CommonStates��63   ._�5@      �� $ contentPresenter��6/   $��0,2,2,2q�5A   /   #��z��5B   /   #��z��5C   /   # �   5D   /   |�.  ��. # z 5G   /    . 5H   /   5I       5J      P� 5K       �@J�IsMouseOver . . �5L   "   �� $ border��6)   8
  	 � ��6S   �� 5M   "   $ border��6)   8
  	 � ��6T   5N      P� 5O       � �� . . �5P   "   �� $ border��6)   8
  	 � ��6S   �� 5Q   "   $ border��6)   8
  	 � ��6T   5R      P� 5S       � {� .  . �5T   "   �� $ border��6)   8
  	 � ��6S   �� 5U   "   $ border��6)   8
  	 � ��6T   �� 5V   "   $ contentPresenter��6)   8
 	 	 � ��6i   5W      5Y      5[      �� 5\      	 � ��$
 Center=�69   5]      5^      .��5_      ]� -   5        $��Panel1��5_      # [  6   ��5`   
   �� 5a       j� 
AlignmentX$
 Left=�6    j� 
AlignmentY$ Center=�5b       �� ImageSource$ 	urban.jpg��5c       j� Stretch$
 None=�5d       5g   
    
 MyEnum S� 
MethodName S� 
ObjectType   System.Enum  S� MethodParameters! M� TypeName  
TargetEnum��%  &	       &	 �     S� 5i      $ 	GetValues��5j   !   "  5k   !     5l      M� 5m      $$! core:EnvironmentVariableTarget��6   5o      S� 5p      $ 	GetValues��5q   !   "  5r   !     5s      M� 5t      $! local:EnvVarTarget��6   5v      5w      .+�5x   
   �� $	��Top=�6   # [  5y      " �� Orientation$" Vertical=�5z      .+�5{      �� $	��Top=�6   $��RightToLeft=�5|      $" 
Horizontal=�5}      .+�5~      �� -   5        $	��125��5~      $��50��5      ���	#003CA31E
������ # �� 	ClickMode$# Release=�5�      $
��Help��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $ � ToolTip$B$ <exports the enviornment variable entry at the selected index��5�      �� 5�      -   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $��Export��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $B$ <exports the enviornment variable entry at the selected index��5�      �� 5�      -   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $��Import��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $B$ <imports the enviornment variable entry at the selected index��5�      �� 5�      -   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $��Clean��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $A$ ;cleans the enviornment variable entry at the selected index��5�      �� 5�      -   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $��Remove��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $B$ <removes the enviornment variable entry at the selected index��5�      �� 5�      -   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $
��Edit��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $@$ :edits the enviornment variable entry at the selected index��5�      �� 5�      -	   5        $	��125��5�      $��50��5�      ���	#003CA31E
������ $# Release=�5�      $	��Add��5�      $��Stencil Std)�5�      $��18.667(�5�      #���  5�      $.$ (adds an enviornment variable to the list��5�      5�      �� 5�      $
��Left=�6   $	��Top=�5�      $" 
Horizontal=�5�      .+�5�      �� $��24��6   $
��Left=�5�      $��Bottom=�5�      $��14.667(�5�      $
��Bold"�5�      $%��Enviornment Variable Management��5�      �� 5�      $��Right=�6   $" 
Horizontal=�69   .+�5�      �� -
   5        % ��Name$% UseShortPathsBox��5�      $��
300,0,10,0q�5�      $��Right=�5�      $��Center=�5�      $��Use Short Paths��5�      $
��Bold"�5�      $M$ Gconverts variables to their short value representation during clean up.��5�      & d� 	IsChecked& 5�      �� *UseShortPaths+' �� RelativeSource' �� *FindAncestor+( �� AncestorType  EnvCleanerUI.MainWindow"(  5�      �� 5�      -   5        $!% DeleteUnconfirmedEntriesBox��5�      $��	10,0,10,0q�5�      $��Right=�5�      $��Center=�5�      $ ��Delete Unconfirmed Entries��5�      $
��Bold"�5�      $I$ Cdeletes variables whose paths can not be confirmed during clean up.��5�      & 5�      �� *DeleteUnconfirmedEntries+' �� *FindAncestor+"(  5�      �� 5�      -   5        $��OptionComboBox��5�      $	��100��5�      $��Right=�5�      ��5�      �� ) �� Source#) [ * �� SelectedItem* 5�      �� *OptionTarget+' �� *FindAncestor+"(  5�      5�      �� 5�      $��4��5�      $
��Left=�5�      
���   �$��1q�5�      # [  5�      $y�Visible=�5�      ��5�      �� *Width+' �� *FindAncestor+"(  5�      5�      �� 5�   
   -   5        $��Viewer1��5�      $��Hidden=�6&   .��5�      &   System.Windows.Controls.DataGrid  -   5        +  Name$	+ Dg1��5�      ,   AutoGenerateColumns, .  ��5      �� -   Columns- 5     0  *System.Windows.Controls.DataGridTextColumn  5     ,  &System.Windows.Controls.DataGridColumn.   MaxWidth$	. 250Q�6)   /   CanUserReorder/ .  0   Header$
0 Name��5  )   1   
IsReadOnly1 . 1	  +System.Windows.Controls.DataGridBoundColumn2 	  Binding2 5  )   �� *Name+5  )     5     $	. 543Q�6)   / .  $0 Value��5
  )   1 . 2 5  )   �� *Value+5  )   4
  .System.Windows.Controls.DataGridComboBoxColumn
  5     3   Width5  /System.Windows.Controls.DataGridLengthConverter$	3 100 6-   / .  $0 Target��5  -   1 . 4 
  ItemsSource4 5  -   �� #) [ 5 
  SelectedItemBinding5 5  -   �� *Target+5     5     5     5     