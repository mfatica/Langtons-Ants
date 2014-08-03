Langtons-Ants
=============

C# Implementation of Advanced Langton's Ants

Supports both GUI and command line. 
usage: ants [options] -steps <num steps> -w <grid width> -h <grid height>
        options:
                -ants <x1,y1;x2,y2>
                        Specify ant start postition
                        Default is center
                -turns <turns>
                        Requires -colors
                        Specify turns
                -colors <colors>
                        Requres -turns
                        Specify tile colors
                -antcolor <color>
                        Specify ant color
                -gridlines
                        Enable grid lines
                -gridcolor <color>
                        Grid line color
                -o <filename>
                        Output file name
        format:
                <color> Name of color, comma delimited
                <turn>  L or R, comma delimited
                <x,y>   xy position, semicolon delimited

to-do:
- Save settings
- Refactor messy code
