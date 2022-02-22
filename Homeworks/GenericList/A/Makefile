OUT = Out.data
IN = Input.data

all: $(OUT)
	cat $<

$(OUT): main.exe $(IN)
	> $@
	echo 'Exercise "Generic List" part A:' >> $@
	echo '\ninput: Irregular table:' >>$@
	cat $(IN) >> $@
	echo '\noutput: Regular table:' >>$@
	mono main.exe < $(IN) >> $@

$(IN): Makefile
	> $@
	echo -1.23 '   '  23.4 '\t   \t' 456.7 >> $@
	echo '  \t    ' 0.07 '  \t\t\t     '  -7.4e8 '\t' 6.72 >> $@
	echo 0.53 23.4 4.5 >> $@

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@ $< -reference:genlist.dll 

genlist.dll: genlist.cs 
	mcs -target:library -out:genlist.dll genlist.cs

.PHONEY: clean
clean: 
		$(RM) [Oo]ut* *.exe