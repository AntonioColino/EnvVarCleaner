   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  G CEnvCleanerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EnvCleanerUIEnvCleanerUI    EnvCleanerUI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7core&clr-namespace:System;assembly=mscorlib     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:EnvCleanerUI     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  MyWindow�� � Title$ 
MainWindow��$	��972��$	��615�� � 
ResizeMode$ NoResize=� � WindowStyle$ 
ToolWindow=� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   MyEffect   
BlurRadius   	Direction   ShadowDepth   Color  FocusVisual	 �� Property
 �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  EnvButtonStyle �� 
TargetType �� 
TargetType ��Name �� CornerRadius J� Effect'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup ��Name � UseLayoutRounding �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 -     &	 {     &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     &		 
    &	
     &	 4    7  7  7  7  7  7  7  7  7 	 7 
   $ 5Q�$	 -45Q�$ 7Q�$ #B4B2B2���� .��� 	 � ��
 �� .R��� $��2q� . #��� ��$	 1 2R�$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ #E0FDBE���� $ 	#FFB1A63C���� $ #F6C4C6���� $ 	#FF8B4A2C���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.��� 	 � ��8
   �� 	 � ��8
  �� 	 � ��$
 1q��� 	 �@�FocusVisualStyle8
  �� 	 � ��#
 � ���� 	 � ��$
 Center=��� 	 � ��$
 1q��� 	 � ��
 �� " ��.R��� $ border��#��z��#��z��$��1q�$ 5��# �    .    CommonStates��._��� $ contentPresenter��$��0,2,2,2q�#��z��#��z��# �   |�.  ��. # z  .  P�  �@J�IsMouseOver . . ��� $ border��8
  	 � ���� $ border��8
  	 � ��P�  � �� . . ��� $ border��8
  	 � ���� $ border��8
  	 � ��P�  � {� .  . ��� $ border��8
  	 � ���� $ border��8
  	 � ���� $ contentPresenter��8
 	 	 � ���� 	 � ��$
 Center=�.��]� -   $��Panel1��# [  ����  j� 
AlignmentX$
 Left=� j� 
AlignmentY$ Center=� �� ImageSource$ 	urban.jpg�� j� Stretch$
 None=�  
 MyEnum S� 
MethodName S� 
ObjectType   System.Enum  S� MethodParameters! M� TypeName  
TargetEnum��%�   &	       &	 H     S� $ 	GetValues��"    M� $$! core:EnvironmentVariableTarget��S� $ 	GetValues��"    M� $! local:EnvVarTarget��.+��� $	��Top=�# [  " �� Orientation$" Vertical=�.+��� $	��Top=�$��RightToLeft=�$" 
Horizontal=�.+��� -   $	��125��$��50�����	#003CA31E
������ # �� 	ClickMode$# Release=�$
��Help��$��Stencil Std)�$��18.667(�#���  $ � ToolTip$B$ <exports the enviornment variable entry at the selected index���� -   $	��125��$��50�����	#003CA31E
������ $# Release=�$��Export��$��Stencil Std)�$��18.667(�#���  $B$ <exports the enviornment variable entry at the selected index���� -   $	��125��$��50�����	#003CA31E
������ $# Release=�$��Import��$��Stencil Std)�$��18.667(�#���  $B$ <imports the enviornment variable entry at the selected index���� -   $	��125��$��50�����	#003CA31E
������ $# Release=�$��Clean��$��Stencil Std)�$��18.667(�#���  $A$ ;cleans the enviornment variable entry at the selected index���� -   $	��125��$��50�����	#003CA31E
������ $# Release=�$��Remove��$��Stencil Std)�$��18.667(�#���  $B$ <removes the enviornment variable entry at the selected index���� -   $	��125��$��50�����	#003CA31E
������ $# Release=�$
��Edit��$��Stencil Std)�$��18.667(�#���  $@$ :edits the enviornment variable entry at the selected index���� -	   $	��125��$��50�����	#003CA31E
������ $# Release=�$	��Add��$��Stencil Std)�$��18.667(�#���  $.$ (adds an enviornment variable to the list���� $
��Left=�$	��Top=�$" 
Horizontal=�.+��� $��24��$
��Left=�$��Bottom=�$��14.667(�$
��Bold"�$%��Enviornment Variable Management���� $��Right=�$" 
Horizontal=�.+��� -
   % ��Name$% UseShortPathsBox��$��
300,0,10,0q�$��Right=�$��Center=�$��Use Short Paths��$
��Bold"�$M$ Gconverts variables to their short value representation during clean up.��& d� 	IsChecked& �� *UseShortPaths+' �� RelativeSource' �� *FindAncestor+( �� AncestorType  EnvCleanerUI.MainWindow"(  �� -   $!% DeleteUnconfirmedEntriesBox��$��	10,0,10,0q�$��Right=�$��Center=�$ ��Delete Unconfirmed Entries��$
��Bold"�$I$ Cdeletes variables whose paths can not be confirmed during clean up.��& �� *DeleteUnconfirmedEntries+' �� *FindAncestor+"(  �� -   $��OptionComboBox��$	��100��$��Right=����� ) �� Source#) [ * �� SelectedItem* �� *OptionTarget+' �� *FindAncestor+"(  �� $��4��$
��Left=�
���   �$��1q�# [  $y�Visible=����� *Width+' �� *FindAncestor+"(  �� -   $��Viewer1��$��Hidden=�.��&   System.Windows.Controls.DataGrid  -   +  Name$	+ Dg1��,   AutoGenerateColumns, .  ���� -   Columns- 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn.   MaxWidth$	. 250Q�/   CanUserReorder/ .  0   Header$
0 Name��1   
IsReadOnly1 . 1	  +System.Windows.Controls.DataGridBoundColumn2 	  Binding2 �� *Name+  $	. 543Q�/ .  $0 Value��1 . 2 �� *Value+4
  .System.Windows.Controls.DataGridComboBoxColumn
  3   Width5  /System.Windows.Controls.DataGridLengthConverter$	3 100 / .  $0 Target��1 . 4 
  ItemsSource4 �� #) [ 5 
  SelectedItemBinding5 �� *Target+