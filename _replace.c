#include <stdio.h>
#include <string.h>

int main(int argc,char **argv)
{
    char *filename = argv[1];
    if(argc != 2){return 1;}/*�t�@�C���w�肪�Ȃ��ꍇ,�ُ�I��*/

    /*�t�@�C���W�J*/
    {
        #define LineMaxSize 100
        #define TempFileNameSize 100
        FILE *fp,*fq;
        int line = 0;
        char str[LineMaxSize];
        char tempfilename[TempFileNameSize];

        /*�ǂݍ��݃t�@�C���I�[�v��*/
        if( ( fp = fopen(filename,"r") ) == NULL )
        {
            printf("ERROR:Can not Open %s",filename);
            return 2;
        }

        /*�������݃t�@�C���I�[�v��*/
        strcpy(tempfilename,filename);
        strcat(tempfilename,"_temp.c");
        fq = fopen(tempfilename,"w");

        /*�P�s���ǂݍ���*/
        while(fgets(str, LineMaxSize , fp) != NULL) {
            char *index = NULL;
            line++;

            /*�v���v�����̌����Ώۍs��?*/
            if(
                strstr(str,"#")                 != NULL &&
                (index = strstr(str,"C_SW"))    != NULL &&
                strstr(str,"==")                != NULL &&
                strstr(str,"2")                 != NULL 
            )
            {
                /* if��������else�̌��̈ʒu�������B */
                char *p = ( strstr(str,"if") != NULL ) ? strstr(str,"if")+2 : strstr(str,"else")+4 ;
                char *addstr; /*�u�������镶����*/
                
                if( strstr(str,"1") != NULL )
                {
                    /* 1 ������ */
                    if( strstr(str,"if") != NULL )
                    {
                        /* if/elif���̌�� */
                        addstr = "( ( C_SW == 1 ) || ( C_SW == 2 ) || ( C_SW == 3 ) )\n";
                    }
                    else
                    {
                        /* else���̌��(�R�����g) */
                        addstr = " /* ( ( C_SW == 1 ) || ( C_SW == 2 ) || ( C_SW == 3 ) ) */\n";
                    }
                }
                else
                {
                    /* 1 ���Ȃ� */
                    if( strstr(str,"if") != NULL )
                    {
                        /* if/elif���̌�� */
                        addstr = "( ( C_SW == 2 ) || ( C_SW == 3 ) )\n";
                    }
                    else
                    {
                        /* else���̌��(�R�����g) */
                        addstr = " /* ( ( C_SW == 2 ) || ( C_SW == 3 ) ) */\n";
                    }
                }

                /*�u��*/
                printf("%s:%d�s��\n",filename,line);
                printf("  �ύX�O�F%s",str);
                strcpy(p,addstr);
                printf("  �ύX��F%s\n",str);
            }
            /*�v���v�����ŉ��s����Ă�����x����\��*/
            else if
            (
                strstr(str,"#")  != NULL &&
                strstr(str,"\\") != NULL 
            )
            {
                printf("CAUTION:���̃v���v���s�͉��s����Ă��܂�(%s:%d�s��)\n\n",filename,line);
            }
            /*�v���v�����ŁI��������Όx����\��*/
            else if
            (
                strstr(str,"#")                 != NULL &&
                (index = strstr(str,"C_SW"))    != NULL &&
                strstr(str,"!=")                != NULL 
            )
            {
                printf("CAUTION:���̃v���v���s��!=������܂�(%s:%d�s��)\n\n",filename,line);
            }

            /*TEMP�ɏ�������*/
            fprintf(fq,"%s",str);
        }

        /*�t�@�C���N���[�Y*/
        fclose(fp);
        fclose(fq);
    }

    return 0;
}