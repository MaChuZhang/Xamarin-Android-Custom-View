using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
namespace CustomeTitleBar
{
    public class MyTitleBar : RelativeLayout
    {
        private TextView title_bar_title;
        private Button title_bar_left_btn;
        private Button title_bar_right_btn;
        public MyTitleBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            //base(context, attrs);
            LayoutInflater.From(context).Inflate(Resource.Layout.TitleBar, this, true);
            title_bar_left_btn = FindViewById<Button>(Resource.Id.titleBar_left_btn);
            title_bar_right_btn = FindViewById<Button>(Resource.Id.titleBar_right_btn);
            title_bar_title = FindViewById<TextView>(Resource.Id.title_bar_title);

            try
            {
                TypedArray attributes = context.ObtainStyledAttributes(attrs, Resource.Styleable.CustomeTitleBar);
                if (attributes != null)
                {
                    //titlebar ������ɫ

                    int titleBarBackground = attributes.GetResourceId(Resource.Styleable.CustomeTitleBar_title_background_color,Resource.Color.color_primary);
                    SetBackgroundResource(titleBarBackground);

                    //��߰�ť
                    //�Ƿ���ʾ
                    bool leftButtonVisible = attributes.GetBoolean(Resource.Styleable.CustomeTitleBar_left_button_visible, true);
                    if (leftButtonVisible)
                    {
                        title_bar_left_btn.Visibility = ViewStates.Visible;
                    }
                    else
                    {
                        title_bar_left_btn.Visibility = ViewStates.Gone;
                    }

                    //������߰�ť�����ֺ�ͼ�꣨����ֻ��ѡ��һ��
                    string leftButtonText = attributes.GetString(Resource.Styleable.CustomeTitleBar_left_button_text);
                    if (!string.IsNullOrEmpty(leftButtonText))
                    {
                        title_bar_left_btn.Text = leftButtonText;
                        //������߰�ť��������ɫ
                        Color leftButtonTextColor = attributes.GetColor(Resource.Styleable.CustomeTitleBar_left_button_text_color, Color.White);
                        title_bar_left_btn.SetTextColor(leftButtonTextColor);
                    }
                    else //(�������ı�����ֻ������ͼ��)
                    {
                        int leftButtonDrawable = attributes.GetResourceId(Resource.Styleable.CustomeTitleBar_left_button_drawable, Resource.Drawable.icon_white_arrow_left);
                        if (leftButtonDrawable != -1)
                        {
                            Drawable drawable = Resources.GetDrawable(leftButtonDrawable);
                            drawable.SetBounds(0, 0, drawable.MinimumWidth,drawable.MinimumHeight);//���������ͼ����ʾ������
                            title_bar_left_btn.SetCompoundDrawables(drawable,null,null,null);
                        }
                    }

                    //�ұ߰�ť
                    //�Ƿ���ʾ
                    bool rightButtonVisible = attributes.GetBoolean(Resource.Styleable.CustomeTitleBar_right_button_visible, true);
                    if (rightButtonVisible)
                    {
                        title_bar_right_btn.Visibility = ViewStates.Visible;
                    }
                    else
                    {
                        title_bar_right_btn.Visibility = ViewStates.Gone;
                    }

                    //������߰�ť�����ֺ�ͼ�꣨����ֻ��ѡ��һ��
                    string rightButtonText = attributes.GetString(Resource.Styleable.CustomeTitleBar_right_button_text);
                    if (!string.IsNullOrEmpty(rightButtonText))
                    {
                        title_bar_right_btn.Text = rightButtonText;
                        //������߰�ť��������ɫ
                        Color leftButtonTextColor = attributes.GetColor(Resource.Styleable.CustomeTitleBar_right_button_text_color, Color.White);
                        title_bar_right_btn.SetTextColor(leftButtonTextColor);
                    }
                    else //(�������ı�����ֻ������ͼ��)
                    {
                        int rightButtonDrawable = attributes.GetResourceId(Resource.Styleable.CustomeTitleBar_right_button_drawable, Resource.Drawable.icon_white_arrow_left);
                        if (rightButtonDrawable != -1)
                        {
                            Drawable drawable = Resources.GetDrawable(rightButtonDrawable);
                            drawable.SetBounds(0,0,drawable.MinimumHeight,drawable.MinimumHeight);
                            title_bar_right_btn.SetCompoundDrawables(null, null,drawable, null);
                        }
                    }
                    //�������
                    string titleText = attributes.GetString(Resource.Styleable.CustomeTitleBar_title_text);
                    if (!string.IsNullOrEmpty(titleText))
                    {
                        title_bar_title.Text = titleText;
                    }
                    Color color = attributes.GetColor(Resource.Styleable.CustomeTitleBar_title_text_color,Color.White);
                    title_bar_title.SetTextColor(color);
                    attributes.Recycle();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }
        
        //�����¼��ļ���
        public void SetTitleClickListener(IOnClickListener onClickListener)
        {
            if (onClickListener != null)
            {
                title_bar_left_btn.SetOnClickListener(onClickListener);
                title_bar_right_btn.SetOnClickListener(onClickListener);
            }
        }
        //��ȡ��ߵ�Button
        public Button GetTitleBarLeftBtn()
        {
            return title_bar_left_btn;
        }
        //��ȡ�ұߵ�Button
        public Button GetTitleRightBtn()
        {
            return title_bar_right_btn;
        }
        //��ȡ����
        public TextView GetTitleBarTitle()
        {
            return title_bar_title;
        }
    }
}