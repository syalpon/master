#include <stdio.h>
#include <string.h>

int main(int argc,char **argv)
{
    char *filename = argv[1];
    if(argc != 2){return 1;}/*ファイル指定がない場合,異常終了*/

    /*ファイル展開*/
    {
        #define LineMaxSize 100
        #define TempFileNameSize 100
        FILE *fp,*fq;
        int line = 0;
        char str[LineMaxSize];
        char tempfilename[TempFileNameSize];

        /*読み込みファイルオープン*/
        if( ( fp = fopen(filename,"r") ) == NULL )
        {
            printf("ERROR:Can not Open %s",filename);
            return 2;
        }

        /*書き込みファイルオープン*/
        strcpy(tempfilename,filename);
        strcat(tempfilename,"_temp.c");
        fq = fopen(tempfilename,"w");

        /*１行ずつ読み込み*/
        while(fgets(str, LineMaxSize , fp) != NULL) {
            char *index = NULL;
            line++;

            /*プリプロ文の検索対象行か?*/
            if(
                strstr(str,"#")                 != NULL &&
                (index = strstr(str,"C_SW"))    != NULL &&
                strstr(str,"==")                != NULL &&
                strstr(str,"2")                 != NULL 
            )
            {
                /* ifもしくはelseの後ろの位置を検索。 */
                char *p = ( strstr(str,"if") != NULL ) ? strstr(str,"if")+2 : strstr(str,"else")+4 ;
                char *addstr; /*置き換える文字列*/
                
                if( strstr(str,"1") != NULL )
                {
                    /* 1 がある */
                    if( strstr(str,"if") != NULL )
                    {
                        /* if/elif文の後ろ */
                        addstr = "( ( C_SW == 1 ) || ( C_SW == 2 ) || ( C_SW == 3 ) )\n";
                    }
                    else
                    {
                        /* else文の後ろ(コメント) */
                        addstr = " /* ( ( C_SW == 1 ) || ( C_SW == 2 ) || ( C_SW == 3 ) ) */\n";
                    }
                }
                else
                {
                    /* 1 がない */
                    if( strstr(str,"if") != NULL )
                    {
                        /* if/elif文の後ろ */
                        addstr = "( ( C_SW == 2 ) || ( C_SW == 3 ) )\n";
                    }
                    else
                    {
                        /* else文の後ろ(コメント) */
                        addstr = " /* ( ( C_SW == 2 ) || ( C_SW == 3 ) ) */\n";
                    }
                }

                /*置換*/
                printf("%s:%d行目\n",filename,line);
                printf("  変更前：%s",str);
                strcpy(p,addstr);
                printf("  変更後：%s\n",str);
            }
            /*プリプロ文で改行されていたら警告を表示*/
            else if
            (
                strstr(str,"#")  != NULL &&
                strstr(str,"\\") != NULL 
            )
            {
                printf("CAUTION:このプリプロ行は改行されています(%s:%d行目)\n\n",filename,line);
            }
            /*プリプロ文で！＝があれば警告を表示*/
            else if
            (
                strstr(str,"#")                 != NULL &&
                (index = strstr(str,"C_SW"))    != NULL &&
                strstr(str,"!=")                != NULL 
            )
            {
                printf("CAUTION:このプリプロ行は!=があります(%s:%d行目)\n\n",filename,line);
            }

            /*TEMPに書き込み*/
            fprintf(fq,"%s",str);
        }

        /*ファイルクローズ*/
        fclose(fp);
        fclose(fq);
    }

    return 0;
}