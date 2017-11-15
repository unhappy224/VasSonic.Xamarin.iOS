XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=VasSonic.iOS.Binding/Static/Pods/Pods.xcodeproj
TARGET=VasSonic
DEPLOYMENTTARGET=8.0
NAME=VasSonic
CONFIG=Release
Dir=VasSonic.iOS.Binding/Static

all: $(NAME).dll
Pod.lock:
	cd $(Dir) && pod install
	
$(NAME)-x86.framework: Pod.lock
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphonesimulator -configuration $(CONFIG) clean build
	-mv $(Dir)/$(PROJECT_ROOT)/build/$(CONFIG)-iphonesimulator/$(TARGET)/$(TARGET).framework $(Dir)/$@

$(NAME)-arm.framework: Pod.lock
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphoneos -configuration $(CONFIG) clean build
	-mv $(Dir)/$(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/$(TARGET)/$(TARGET).framework/ $(Dir)/$@

$(NAME).framework: Pod.lock $(NAME)-arm.framework $(NAME)-x86.framework
	-rm -f $(Dir)/$(NAME).framework
	-cp -r $(Dir)/$(NAME)-arm.framework  $(Dir)/$(NAME).framework
	lipo -create -output $(Dir)/$(NAME).framework/$(NAME) $(Dir)/$(NAME)-arm.framework/$(NAME) $(Dir)/$(NAME)-x86.framework/$(NAME)

$(NAME).dll: $(NAME).framework
	msbuild VasSonic.iOS.Binding /p:Configuration=Release /t:Rebuild /p:OutputPath=../Out

native: $(NAME).framework

device: $(NAME)-arm.framework
	-rm -f $(Dir)/$(NAME).framework
	-cp -r $(Dir)/$(NAME)-arm.framework  $(Dir)/$(NAME).framework
	msbuild VasSonic.iOS.Binding /p:Configuration=Release /t:Rebuild /p:OutputPath=../Out/Device

nuget:
	nuget pack Package.nuspec -Version 1.0.0

clean: 
	-rm -f *.nupkg
	-rm -rf ./Out
	-rm -rf $(Dir)/*.framework
	-rm -rf $(Dir)/Static/build
	-rm -rf $(Dir)/Static/Pods
	-rm -f $(Dir)/Static/Podfile.lock
	-rm -rf VasSonic.iOS.Binding/bin
	-rm -rf VasSonic.iOS.Binding/obj
	-rm -rf VasSonic.iOS.Demo/bin
	-rm -rf VasSonic.iOS.Demo/obj
	-rm -rf VasSonic.iOS.Demo/obj